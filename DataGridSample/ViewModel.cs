using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace DataGridSample
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public DataTable? DataTable { get; private set; }

        Command? _SelectDataCommand;

        public ICommand SelectDataCommand => _SelectDataCommand ??= new((o) =>
        {
            if (o is string str)
            {
                var columns = 20 + (int.TryParse(str, out int i) ? i * 2 : 0);

                static IEnumerable<string> Columns(int n) => Enumerable
                .Range(0, n)
                .Select(_ => Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));

                DataTable = new();
                DataTable.Columns.AddRange(Columns(columns).Select(n => new DataColumn(n)).ToArray());
                _ = Enumerable.Range(0, 10).Select(_ => DataTable.Rows.Add(Columns(columns).ToArray())).ToArray();
            }
            else
            {
                DataTable = null;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataTable)));
        });

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
