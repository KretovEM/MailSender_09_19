using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestMailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для ListController.xaml
    /// </summary>
    public partial class ListController
    {
        #region Items property
        public static readonly DependencyProperty ItemsProperty =
             DependencyProperty.Register(
                 "Items",
                 typeof(IEnumerable),
                 typeof(ListController),
                 new PropertyMetadata(default(IEnumerable), OnItemsChanged, ItemsCoerceValue),
                 itemsValidate
                );

        private static bool itemsValidate(object value) => true;

        private static object ItemsCoerceValue(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e){}

        public IEnumerable Items
        {
            get => (IEnumerable)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        #endregion

        #region SelectedItem : object - Выбранный элемент

        [Description("Выбранный элемент") ]
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem", 
                typeof(object), 
                typeof(ListController), 
                new PropertyMetadata(default(object)));

        #endregion

        #region PanelName

        [Description("Название панели")]
        public string PanelName
        {
            get { return (string)GetValue(PanelNameProperty); }
            set { SetValue(PanelNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PanelName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register("PanelName", typeof(string), typeof(ListController), new PropertyMetadata(default(string)));

        #endregion

        #region SelectedItemIndex

        [Description("Индекс выбранного элемента")]
        public int SelectedItemIndex
        {
            get { return (int)GetValue(SelectedItemIndexProperty); }
            set { SetValue(SelectedItemIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItemIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemIndexProperty =
            DependencyProperty.Register("SelectedItemIndex", typeof(int), typeof(ListController), new PropertyMetadata(0));

        #endregion

        #region ViewPropertyPath

        [Description("Имя отображаемого свойства")]
        public string ViewPropertyPath
        {
            get { return (string)GetValue(ViewPropertyPathProperty); }
            set { SetValue(ViewPropertyPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewPropertyPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewPropertyPathProperty =
            DependencyProperty.Register("ViewPropertyPath", typeof(string), typeof(ListController), new PropertyMetadata(default(string)));

        #endregion

        #region ValuePropertyPath

        [Description("Имя свойства значения")]
        public string ValuePropertyPath
        {
            get { return (string)GetValue(ValuePropertyPathProperty); }
            set { SetValue(ValuePropertyPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValuePropertyPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValuePropertyPathProperty =
            DependencyProperty.Register("ValuePropertyPath", typeof(string), typeof(ListController), new PropertyMetadata(default(string)));


        #endregion

        #region ItemTemplate

        [Description("Шаблон визуализации данных")]
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(ListController), new PropertyMetadata(default(DataTemplate)));


        #endregion

        #region Commands

        #region CreateCommand

        [Description("Команда создания нового значения")]
        public ICommand CreateCommand
        {
            get { return (ICommand)GetValue(CreateCommandProperty); }
            set { SetValue(CreateCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateCommandProperty =
            DependencyProperty.Register("CreateCommand", typeof(ICommand), typeof(ListController), new PropertyMetadata(default(ICommand)));

        #endregion

        #region EditCommand

        [Description("Команда редактирования значения")]
        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(ListController), new PropertyMetadata(default(ICommand)));


        #endregion

        #region DeleteCommand

        [Description("Команда удаления элемента")]
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(ListController), new PropertyMetadata(default(ICommand)));


        #endregion

        #endregion
        public ListController() => InitializeComponent();
    }
}
