using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ComboBoxTest
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ComboBoxList = new ObservableCollection<string>
            {
                "",
                "test",
                "abc",
                "def"
            };
        }

        private ObservableCollection<string> comboBoxList { get; set; }
        public ObservableCollection<string> ComboBoxList
        {
            get => comboBoxList;
            set
            {
                if (value == comboBoxList)
                    return;
                comboBoxList = value;
                RaisePropertyChanged(nameof(ComboBoxList));
            }
        }

        private string textBoxValue;
        public string TextBoxValue
        {
            get => textBoxValue;
            set
            {
                // 例えば "test" という文字が選択された場合、選択できなくする
                if (value != "test")
                {
                    textBoxValue = value;
                }
                // ComboBox以外にも通知する
                RaisePropertyChanged(nameof(TextBoxValue));
            }
        }
    }
}
