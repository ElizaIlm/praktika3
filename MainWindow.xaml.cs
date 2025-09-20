using System;
using System.Collections.Generic;
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
using pr3.Classes;


namespace pr3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pawn> Pawns = new List<Pawn>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;

            for (int i = 0; i < 7; i++)
            {
                Pawns.Add(new Pawn(i,1,false));
                Pawns.Add(new Pawn(i, 6, true));
            }
            CreateFigure();
        }

        public void CreateFigure()
        {
            foreach(Pawn Pawn in Pawns)
            {
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if(Pawn.Black)
                    Pawn.Figure.Background= new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,, /Images/Pawn (black).png")));
                else
                {
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,, /Images/Pawn.png")));

                }
                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);
            }
        }

        public void OnSelect(Pawn pawn)
        {
            foreach (Pawn Pawn in Pawns)
            {
                if (Pawn != pawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);
            }
        }

        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Title = sender as Grid;
            int X = Grid.GetColumn(Title);
            int Y = Grid.GetRow(Title);
            Pawn SelectPawn = MainWindow.init.Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }
        }
    }
}
