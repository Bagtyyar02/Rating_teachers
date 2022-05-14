using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using TileBar_from_code.Model;
using TileBar_from_code.Model.DbModel;
using TileBar_from_code.Model.GridModel;

namespace TileBar_from_code.ViewModel
{
    class AddTeacherViewModel : ViewModelBase
    {
        #region properties
        private INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
        public string s_index { get; set; }

        // public DataPoint dt1 { get; set; }
        private int _selected_teacher_id;
        public int selected_teacher_id
        {
            get { return _selected_teacher_id; }
            set
            {
                SetValue(ref _selected_teacher_id, value);
            }
        }
        public DelegateCommand TeacherDeleteCommand { get; set; }
        private tbl_br_teachers _tbl_teacher;
        public tbl_br_teachers tbl_teacher
        {
            get { return _tbl_teacher; }
            set
            {
                SetValue(ref _tbl_teacher, value);
            }
        }
        private ObservableCollection<string> _teacher_state;
        public ObservableCollection<string> teacher_state
        {
            get { return _teacher_state; }
            set
            {
                SetValue(ref _teacher_state, value);
            }
        }
        private ObservableCollection<AddTasksModel> _Tasks_per_teacher;
        public ObservableCollection<AddTasksModel> Tasks_per_teacher
        {
            get { return _Tasks_per_teacher; }
            set
            {
                SetValue(ref _Tasks_per_teacher, value);
            }
        }
        private ObservableCollection<Main_chart_model> _Chart_Model;
        public ObservableCollection<Main_chart_model> Chart_Model
        {
            get { return _Chart_Model; }
            set
            {
                SetValue(ref _Chart_Model, value);
            }
        }
        public DelegateCommand SaveAndCloseCommand { get; set; }
        //public DelegateCommand AddTaskCommand { get; set; }
        private XPCollection<tbl_br_teachers> _tbl_br_teachers;
        public XPCollection<tbl_br_teachers> __tbl_br_teachers
        {
            get { return _tbl_br_teachers; }
            set { SetValue(ref _tbl_br_teachers, value); }
        }
        private XPCollection<tbl_br_tasks> _tbl_br_tasks;
        public XPCollection<tbl_br_tasks> __tbl_br_tasks
        {
            get { return _tbl_br_tasks; }
            set { SetValue(ref _tbl_br_tasks, value); }
        }
        private XPCollection<tbl_br_actions> _tbl_br_actions;
        public XPCollection<tbl_br_actions> __tbl_br_actions
        {
            get { return _tbl_br_actions; }
            set { SetValue(ref _tbl_br_actions, value); }
        }
        private XPCollection<tbl_br_actions> _actions_per_teacher;
        public XPCollection<tbl_br_actions> __actions_per_teacher
        {
            get { return _actions_per_teacher; }
            set { SetValue(ref _actions_per_teacher, value); }
        }

        private XPCollection<tbl_br_faculties> _faculties;
        public XPCollection<tbl_br_faculties> faculties
        {
            get { return _faculties; }
            set { SetValue(ref _faculties, value); }
        }
        public string selected_state { get; set; }

        #endregion
        UnitOfWork uow;
        #region constructor
        public AddTeacherViewModel()
        {
            uow = new UnitOfWork();
            __tbl_br_teachers = new XPCollection<tbl_br_teachers>(uow);
            _tbl_br_tasks = new XPCollection<tbl_br_tasks>(uow);
            tbl_teacher = new tbl_br_teachers(uow);
            faculties = new XPCollection<tbl_br_faculties>(uow);

            SaveAndCloseCommand = new DelegateCommand(() => SaveCommand());
            TeacherDeleteCommand = new DelegateCommand(() => DeleteCommand());
            Tasks_per_teacher = new ObservableCollection<AddTasksModel>();
            Chart_Model = new ObservableCollection<Main_chart_model>();

            GetTasksPerTeacher();


            teacher_state = new ObservableCollection<string>();
            teacher_state.Add("Öwreniji mugallym");
            teacher_state.Add("Mugallym");
            teacher_state.Add("Uly mugallym");
            selected_state = teacher_state[1];
        
        }

        private void DeleteCommand()
        {
            try
            {
                tbl_br_teachers delete_teacher = uow.GetObjectByKey<tbl_br_teachers>(selected_teacher_id);
               // XPCollection<tbl_br_actions> delete_actions = new XPCollection<tbl_br_actions>(uow,CriteriaOperator.Parse($"teacher_id={selected_teacher_id}"));
                uow.Delete(delete_teacher);
                uow.Delete(new XPCollection<tbl_br_actions>(uow, CriteriaOperator.Parse($"teacher_id={selected_teacher_id}")));
                uow.CommitChanges();
                //NavigationService.GoBack();
                NavigationService.ClearCache();
                NavigationService.ClearNavigationHistory();
                NavigationService.Navigate("MainView","teacher_delete",this);
            }
            catch (Exception)
            {

                throw;
            }
            //throw new NotImplementedException();
        }


        #endregion

        #region Procedures
        public void OnChanged()
        {
            Debug.Print("HEllo");
        }
        protected override void OnParameterChanged(object parameter)
        {
            if (parameter != null)
            {
                uow.DropChanges();
                selected_teacher_id = Convert.ToInt32(parameter);
                //var ob = new XPCollection<tbl_br_faculties>(uow, CriteriaOperator.Parse($"faculty_name={}"))
                decimal point = 0;

                tbl_teacher = uow.GetObjectByKey<tbl_br_teachers>(selected_teacher_id);
                //tbl_br_faculties bd = (tbl_br_faculties)uow.FindObject(typeof(tbl_br_faculties),CriteriaOperator.Parse($"faculty_name={tbl_teacher.teacher_faculty}"));
                //s_index = bd.faculty_name;
                Tasks_per_teacher = new ObservableCollection<AddTasksModel>();
                _tbl_br_actions = new XPCollection<tbl_br_actions>(uow, CriteriaOperator.Parse($"teacher_id={selected_teacher_id}"));
                GetTasksPerTeacher();
                string query = ";with cteRowNumber as (select action_id, task_id, teacher_id, modified_date, task_point, spe_code1 as mukdar, task_code, " +
                               "row_number() over(partition by task_id order by modified_date desc) as RowNum " +
                               $"from tbl_br_actions where teacher_id in({selected_teacher_id}) and GCRecord is null) " +
                               "select action_id, teacher_id, task_id, task_point, mukdar, modified_date from cteRowNumber where RowNum = 1";
                ICollection<action_query_model> action1 = uow.GetObjectsFromQuery<action_query_model>(query);
                foreach (action_query_model actions in action1)
                {
                    point += actions.task_point;
                    tbl_br_tasks _task = uow.GetObjectByKey<tbl_br_tasks>(actions.task_id);
                    // max_point += _task.task_max_point;
                    int id = Tasks_per_teacher.IndexOf(Tasks_per_teacher.Where(x => x.task_id == actions.task_id).FirstOrDefault());

                    Tasks_per_teacher[id].task_point = actions.task_point;
                    Tasks_per_teacher[id].task_quantity = Convert.ToDecimal(actions.mukdar);
                    Tasks_per_teacher[id].total_value = Convert.ToDecimal(actions.mukdar)*Tasks_per_teacher[id].max_point;

                }

            }


        }

        private void SaveCommand()
        {
            Debug.Print(tbl_teacher.teacher_id.ToString());
            XPCollection<tbl_br_actions> actions = new XPCollection<tbl_br_actions>(uow);
            try
            {
                if (tbl_teacher.teacher_id == 0)
                {
                    tbl_teacher.teacher_code = Guid.NewGuid().ToString().Substring(0, 4);
                }
                tbl_teacher.Save();
                uow.CommitChanges();
                foreach (AddTasksModel item in Tasks_per_teacher)
                {
                  
                  //  if (item.task_quantity != 0)
                    {
                        tbl_br_actions new_action = new tbl_br_actions(uow);
                        //tbl_br_teachers current_teacher = uow.FindObject<tbl_br_teachers>(CriteriaOperator.Parse($"teacher_id=={tbl_teacher.teacher_id}"));
                        tbl_br_teachers current_teacher = uow.GetObjectByKey<tbl_br_teachers>(tbl_teacher.teacher_id);


                        new_action.task_point = item.max_point*item.task_quantity;
                        new_action.teacher_id = current_teacher.teacher_id;
                        new_action.task_id = item.task_id;
                        new_action.modified_date = DateTime.Now;
                        new_action.spe_code1 = item.task_quantity.ToString();
                        actions.Add(new_action);

                    }




                }

                uow.CommitChanges();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        

            NavigationService.Navigate("MainView", $"save_teacher,{tbl_teacher.teacher_code}", this);
        }

        public void GetTasksPerTeacher()
        {
            Tasks_per_teacher.Clear();
            foreach (tbl_br_tasks item in _tbl_br_tasks)
            {
                AddTasksModel new_task = new AddTasksModel();
                new_task.task_id = item.task_id;
                new_task.task_name = item.task_name;
                new_task.max_point = item.task_max_point;
                new_task.task_short_name = item.task_shortname;
                Tasks_per_teacher.Add(new_task);
            }
        }

        #endregion


    }
}