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
                if (value is string)
                {
                    var _textBoxValue = TextBoxValue;
                    textBoxValue = value;
                    RaisePropertyChanged(nameof(TextBoxValue));

                    if (value == "test")
                    {
                        // 例えば "test" という文字は選択された場合、選択できなくする

                        // 元のデータをバックアップ
                        var _comboBoxList = ComboBoxList.ToList();

                        // リストを更新することで強制的にComboBoxの更新を行う
                        ComboBoxList.Clear();
                        _comboBoxList.ForEach(x => ComboBoxList.Add(x));

                        // 元のデータを戻す
                        textBoxValue = _textBoxValue;
                        RaisePropertyChanged(nameof(TextBoxValue));
                    }
                }
            }
        }
    }
}
