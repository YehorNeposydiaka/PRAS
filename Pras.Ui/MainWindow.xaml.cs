using System.Windows;
using Pras.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

namespace Pras.UI
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Base> Bases { get; set; } = new ObservableCollection<Base>();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                using var context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite("Data Source=Pras.db")
                    .Options);

                // Применяем миграции, чтобы таблицы точно были созданы
                await context.Database.MigrateAsync();

                var basesFromDb = await context.Bases.ToListAsync();

                Bases.Clear();
                foreach (var b in basesFromDb)
                {
                    Bases.Add(b);
                }

                BasesGrid.ItemsSource = Bases; // привязка к DataGrid
            }
            catch (Exception ex)
            {
                // Показываем сообщение об ошибке
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
