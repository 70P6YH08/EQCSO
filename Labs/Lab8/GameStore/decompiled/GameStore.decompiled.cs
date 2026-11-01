using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Resources;
using GameStore;
using GameStore.Models;
using GameStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]
[assembly: AssemblyAssociatedContentFile("images/among_us.jpg")]
[assembly: AssemblyAssociatedContentFile("images/control.jpg")]
[assembly: AssemblyAssociatedContentFile("images/cyberpunk.png")]
[assembly: AssemblyAssociatedContentFile("images/darksouls3.jpg")]
[assembly: AssemblyAssociatedContentFile("images/doom_eternal.jpg")]
[assembly: AssemblyAssociatedContentFile("images/elden_ring.jpeg")]
[assembly: AssemblyAssociatedContentFile("images/godofwar.jpeg")]
[assembly: AssemblyAssociatedContentFile("images/gta5.jpg")]
[assembly: AssemblyAssociatedContentFile("images/hades.jpg")]
[assembly: AssemblyAssociatedContentFile("images/hollow_knight.jpg")]
[assembly: AssemblyAssociatedContentFile("images/last_of_us_2.jpg")]
[assembly: AssemblyAssociatedContentFile("images/minecraft.jpg")]
[assembly: AssemblyAssociatedContentFile("images/portal2.jpg")]
[assembly: AssemblyAssociatedContentFile("images/rdr2.jpg")]
[assembly: AssemblyAssociatedContentFile("images/re_village.jpg")]
[assembly: AssemblyAssociatedContentFile("images/sekiro.jpg")]
[assembly: AssemblyAssociatedContentFile("images/stardew_valley.jpg")]
[assembly: AssemblyAssociatedContentFile("images/terraria.png")]
[assembly: AssemblyAssociatedContentFile("images/valhalla.jpg")]
[assembly: AssemblyAssociatedContentFile("images/witcher3.jpg")]
[assembly: AssemblyAssociatedContentFile("logo.png")]
[assembly: TargetFramework(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]
[assembly: AssemblyCompany("GameStore")]
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+4b05fb9248884ae0539a5a72e37d1289e8fe36a2")]
[assembly: AssemblyProduct("GameStore")]
[assembly: AssemblyTitle("GameStore")]
[assembly: TargetPlatform("Windows7.0")]
[assembly: SupportedOSPlatform("Windows7.0")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: RefSafetyRules(11)]
public class Program
{
	[Serializable]
	[CompilerGenerated]
	private sealed class A
	{
		public static readonly A A;

		public static Action<IServiceCollection> A;

		static A()
		{
			Program.A.A = new A();
		}

		internal void A(IServiceCollection P_0)
		{
			P_0.AddSingleton<App>();
			P_0.AddSingleton<MainWindow>();
		}
	}

	[STAThread]
	public static void Main()
	{
		IHost host = Host.CreateDefaultBuilder().ConfigureServices((IServiceCollection P_0) =>
		{
			P_0.AddSingleton<App>();
			P_0.AddSingleton<MainWindow>();
		}).Build();
		host.Services.GetService<App>()?.Run();
	}
}
namespace GameStore
{
	public class App : Application
	{
		private readonly MainWindow A;

		public App(MainWindow mainWindow)
		{
			A = mainWindow;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			A.Show();
			base.OnStartup(e);
		}
	}
	public class MainWindow : Window, IComponentConnector
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class A
		{
			public static readonly A A;

			public static EventHandler<MessageEventArgs> A;

			static A()
			{
				MainWindow.A.A = new A();
			}

			internal void A(object? s, MessageEventArgs P_1)
			{
				MessageBox.Show(P_1.Message, P_1.Caption, P_1.Button, P_1.Icon);
			}
		}

		private bool m_A;

		public MainWindow()
		{
			InitializeComponent();
			(DataContext as MainViewModel).SendMessage += (object? s, MessageEventArgs P_1) =>
			{
				MessageBox.Show(P_1.Message, P_1.Caption, P_1.Button, P_1.Icon);
			};
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.12.0")]
		public void InitializeComponent()
		{
			if (!this.m_A)
			{
				this.m_A = true;
				Uri resourceLocator = new Uri("/GameStore;component/mainwindow.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.12.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private void A(int P_0, object P_1)
		{
			this.m_A = true;
		}

		void IComponentConnector.Connect(int P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in A
			this.A(P_0, P_1);
		}
	}
	public class MessageEventArgs : EventArgs
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string a;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MessageBoxButton A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MessageBoxImage A;

		public string Message
		{
			[CompilerGenerated]
			get
			{
				return this.A;
			}
			[CompilerGenerated]
			set
			{
				this.A = value;
			}
		}

		public string Caption
		{
			[CompilerGenerated]
			get
			{
				return a;
			}
			[CompilerGenerated]
			set
			{
				a = value;
			}
		}

		public MessageBoxButton Button
		{
			[CompilerGenerated]
			get
			{
				return this.A;
			}
			[CompilerGenerated]
			set
			{
				this.A = value;
			}
		}

		public MessageBoxImage Icon
		{
			[CompilerGenerated]
			get
			{
				return A;
			}
			[CompilerGenerated]
			set
			{
				A = value;
			}
		}

		public MessageEventArgs(string message, string caption, MessageBoxButton button, MessageBoxImage icon)
		{
			Message = message;
			Caption = caption;
			Button = button;
			Icon = icon;
		}
	}
	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> A;

		private readonly Func<T, bool> A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler A;

		public event EventHandler CanExecuteChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = A;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref A, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = A;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref A, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
		{
			this.A = execute;
			this.A = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return this.A == null || this.A((T)parameter);
		}

		public void Execute(object parameter)
		{
			this.A((T)parameter);
		}
	}
	public class SubmitWindow : Window, IComponentConnector
	{
		private bool m_A;

		public SubmitWindow()
		{
			InitializeComponent();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.12.0")]
		public void InitializeComponent()
		{
			if (!this.m_A)
			{
				this.m_A = true;
				Uri resourceLocator = new Uri("/GameStore;component/submitwindow.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.12.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private void A(int P_0, object P_1)
		{
			this.m_A = true;
		}

		void IComponentConnector.Connect(int P_0, object P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in A
			this.A(P_0, P_1);
		}
	}
}
namespace GameStore.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class A
		{
			public static readonly A A;

			public static Func<CartItem, decimal> A;

			public static Func<Key, bool> A;

			public static Action<Key> A;

			static A()
			{
				MainViewModel.A.A = new A();
			}

			internal decimal A(CartItem P_0)
			{
				return P_0.TotalPrice;
			}

			internal bool A(Key P_0)
			{
				return !P_0.IsUsed;
			}

			internal void a(Key P_0)
			{
				P_0.IsUsed = true;
			}
		}

		[CompilerGenerated]
		private sealed class a
		{
			public Game A;

			internal bool A(CartItem P_0)
			{
				return P_0.Game.Id == this.A.Id;
			}
		}

		[CompilerGenerated]
		private sealed class B
		{
			public Game A;

			internal bool A(CartItem P_0)
			{
				return P_0.Game.Id == this.A.Id;
			}
		}

		[CompilerGenerated]
		private sealed class b
		{
			public StringBuilder A;

			public Action<Key> A;

			internal void A(Key P_0)
			{
				this.A.AppendLine(P_0.Code);
			}
		}

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<Game> m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ObservableCollection<CartItem> m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal m_A = 10000m;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ICommand m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ICommand m_a;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ICommand m_B;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ICommand m_b;

		public ObservableCollection<Game> Games
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public ObservableCollection<CartItem> CartItems
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public decimal TotalPrice => CartItems.Sum((CartItem P_0) => P_0.TotalPrice);

		public decimal Balance
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public ICommand AddToCartCommand
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
		}

		public ICommand RemoveFromCartCommand
		{
			[CompilerGenerated]
			get
			{
				return this.m_a;
			}
		}

		public ICommand CheckoutCommand
		{
			[CompilerGenerated]
			get
			{
				return this.m_B;
			}
		}

		public ICommand OrderCommand
		{
			[CompilerGenerated]
			get
			{
				return this.m_b;
			}
		}

		public MainViewModel()
		{
			AppDbContext appDbContext = new AppDbContext();
			try
			{
				Games = new ObservableCollection<Game>(((IEnumerable<Game>)EntityFrameworkQueryableExtensions.Include<Game, IEnumerable<Key>>((IQueryable<Game>)appDbContext.Games, (Expression<Func<Game, IEnumerable<Key>>>)((Game g) => g.Keys))).ToList());
				CartItems = new ObservableCollection<CartItem>();
				this.m_A = new RelayCommand<Game>(AddToCart);
				this.m_a = new RelayCommand<Game>(RemoveFromCart);
				this.m_B = new RelayCommand<object>(A);
			}
			finally
			{
				((IDisposable)appDbContext)?.Dispose();
			}
		}

		public void AddToCart(Game game)
		{
			CartItem cartItem = CartItems.FirstOrDefault((CartItem P_0) => P_0.Game.Id == game.Id);
			if (cartItem == null)
			{
				CartItems.Add(new CartItem
				{
					Game = game,
					Quantity = 1
				});
			}
			else
			{
				cartItem.Quantity++;
			}
			OnPropertyChanged("TotalPrice");
		}

		public void RemoveFromCart(Game game)
		{
			CartItem cartItem = CartItems.FirstOrDefault((CartItem P_0) => P_0.Game.Id == game.Id);
			if (cartItem != null)
			{
				cartItem.Quantity--;
			}
			OnPropertyChanged("TotalPrice");
		}

		private void A(object P_0)
		{
			StringBuilder A = new StringBuilder();
			A.AppendLine("Спасибо за покупку! Ваши ключи:");
			AppDbContext appDbContext = new AppDbContext();
			try
			{
				foreach (CartItem cartItem in CartItems)
				{
					List<Key> list = cartItem.Game.Keys.Where((Key key) => !key.IsUsed).Take(cartItem.Quantity).ToList();
					A.AppendLine(cartItem.Game.Title);
					list.ForEach((Key key) =>
					{
						A.AppendLine(key.Code);
					});
					list.ForEach((Key key) =>
					{
						key.IsUsed = true;
					});
					((DbContext)appDbContext).UpdateRange((IEnumerable<object>)list);
				}
				((DbContext)appDbContext).SaveChanges();
				OnSendMessage(A.ToString());
				Balance -= TotalPrice;
				OnPropertyChanged("Balance");
				CartItems.Clear();
				OnPropertyChanged("TotalPrice");
			}
			finally
			{
				((IDisposable)appDbContext)?.Dispose();
			}
		}
	}
	public class ViewModelBase : INotifyPropertyChanged
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private PropertyChangedEventHandler A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EventHandler<MessageEventArgs> A;

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.A;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.A, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.A;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.A, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		public event EventHandler<MessageEventArgs> SendMessage
		{
			[CompilerGenerated]
			add
			{
				EventHandler<MessageEventArgs> eventHandler = A;
				EventHandler<MessageEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<MessageEventArgs> value2 = (EventHandler<MessageEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref A, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<MessageEventArgs> eventHandler = A;
				EventHandler<MessageEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<MessageEventArgs> value2 = (EventHandler<MessageEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref A, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			this.A?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void OnSendMessage(string message, string caption = "", MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None)
		{
			A?.Invoke(this, new MessageEventArgs(message, caption, button, icon));
		}
	}
}
namespace GameStore.Models
{
	public class AppDbContext : DbContext
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DbSet<Game> A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DbSet<Key> A;

		public DbSet<Game> Games
		{
			[CompilerGenerated]
			get
			{
				return this.A;
			}
			[CompilerGenerated]
			set
			{
				this.A = value;
			}
		}

		public DbSet<Key> Keys
		{
			[CompilerGenerated]
			get
			{
				return A;
			}
			[CompilerGenerated]
			set
			{
				A = value;
			}
		}

		public AppDbContext()
		{
			((DbContext)this).Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			SqliteDbContextOptionsBuilderExtensions.UseSqlite(optionsBuilder, "Data Source=Games.db", (Action<SqliteDbContextOptionsBuilder>)null);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Game>().HasData(new Game[20]
			{
				new Game
				{
					Id = 1,
					Title = "Cyberpunk 2077",
					Price = 1999.99m,
					ImagePath = "Images/cyberpunk.png"
				},
				new Game
				{
					Id = 2,
					Title = "The Witcher 3",
					Price = 1099.99m,
					ImagePath = "Images/witcher3.jpg"
				},
				new Game
				{
					Id = 3,
					Title = "Dark Souls III",
					Price = 1599.99m,
					ImagePath = "Images/darksouls3.jpg"
				},
				new Game
				{
					Id = 4,
					Title = "Doom Eternal",
					Price = 1799.99m,
					ImagePath = "Images/doom_eternal.jpg"
				},
				new Game
				{
					Id = 5,
					Title = "Red Dead Redemption 2",
					Price = 2999.99m,
					ImagePath = "Images/rdr2.jpg"
				},
				new Game
				{
					Id = 6,
					Title = "Assassin's Creed Valhalla",
					Price = 1599.99m,
					ImagePath = "Images/valhalla.jpg"
				},
				new Game
				{
					Id = 7,
					Title = "Hades",
					Price = 799.99m,
					ImagePath = "Images/hades.jpg"
				},
				new Game
				{
					Id = 8,
					Title = "Control",
					Price = 1499.99m,
					ImagePath = "Images/control.jpg"
				},
				new Game
				{
					Id = 9,
					Title = "Resident Evil Village",
					Price = 3999.99m,
					ImagePath = "Images/re_village.jpg"
				},
				new Game
				{
					Id = 10,
					Title = "God of War",
					Price = 3999.99m,
					ImagePath = "Images/godofwar.jpeg"
				},
				new Game
				{
					Id = 11,
					Title = "Elden Ring",
					Price = 3499.99m,
					ImagePath = "Images/elden_ring.jpeg"
				},
				new Game
				{
					Id = 12,
					Title = "Hollow Knight",
					Price = 699.99m,
					ImagePath = "Images/hollow_knight.jpg"
				},
				new Game
				{
					Id = 13,
					Title = "Minecraft",
					Price = 2599.99m,
					ImagePath = "Images/minecraft.jpg"
				},
				new Game
				{
					Id = 14,
					Title = "Terraria",
					Price = 799.99m,
					ImagePath = "Images/terraria.png"
				},
				new Game
				{
					Id = 15,
					Title = "Stardew Valley",
					Price = 599.99m,
					ImagePath = "Images/stardew_valley.jpg"
				},
				new Game
				{
					Id = 16,
					Title = "Among Us",
					Price = 499.99m,
					ImagePath = "Images/among_us.jpg"
				},
				new Game
				{
					Id = 17,
					Title = "The Last of Us Part II",
					Price = 3499.99m,
					ImagePath = "Images/last_of_us_2.jpg"
				},
				new Game
				{
					Id = 18,
					Title = "Grand Theft Auto V",
					Price = 1999.99m,
					ImagePath = "Images/gta5.jpg"
				},
				new Game
				{
					Id = 19,
					Title = "Portal 2",
					Price = 499.99m,
					ImagePath = "Images/portal2.jpg"
				},
				new Game
				{
					Id = 20,
					Title = "Sekiro: Shadows Die Twice",
					Price = 2999.99m,
					ImagePath = "Images/sekiro.jpg"
				}
			});
			modelBuilder.Entity<Key>().HasData(new Key[44]
			{
				new Key
				{
					Id = 1,
					Code = "CYBER-KEY-123",
					GameId = 1
				},
				new Key
				{
					Id = 2,
					Code = "CYBER-KEY-456",
					GameId = 1
				},
				new Key
				{
					Id = 3,
					Code = "CYBER-KEY-789",
					GameId = 1
				},
				new Key
				{
					Id = 4,
					Code = "WITCHER-KEY-123",
					GameId = 2
				},
				new Key
				{
					Id = 5,
					Code = "WITCHER-KEY-456",
					GameId = 2
				},
				new Key
				{
					Id = 6,
					Code = "WITCHER-KEY-789",
					GameId = 2
				},
				new Key
				{
					Id = 7,
					Code = "DARKSOULS-KEY-123",
					GameId = 3
				},
				new Key
				{
					Id = 8,
					Code = "DARKSOULS-KEY-456",
					GameId = 3
				},
				new Key
				{
					Id = 9,
					Code = "DOOM-KEY-123",
					GameId = 4
				},
				new Key
				{
					Id = 10,
					Code = "DOOM-KEY-456",
					GameId = 4
				},
				new Key
				{
					Id = 11,
					Code = "DOOM-KEY-789",
					GameId = 4
				},
				new Key
				{
					Id = 12,
					Code = "RDR-KEY-123",
					GameId = 5
				},
				new Key
				{
					Id = 13,
					Code = "RDR-KEY-456",
					GameId = 5
				},
				new Key
				{
					Id = 14,
					Code = "VALHALLA-KEY-123",
					GameId = 6
				},
				new Key
				{
					Id = 15,
					Code = "VALHALLA-KEY-456",
					GameId = 6
				},
				new Key
				{
					Id = 16,
					Code = "VALHALLA-KEY-789",
					GameId = 6
				},
				new Key
				{
					Id = 17,
					Code = "HADES-KEY-123",
					GameId = 7
				},
				new Key
				{
					Id = 18,
					Code = "HADES-KEY-456",
					GameId = 7
				},
				new Key
				{
					Id = 19,
					Code = "CONTROL-KEY-123",
					GameId = 8
				},
				new Key
				{
					Id = 20,
					Code = "CONTROL-KEY-456",
					GameId = 8
				},
				new Key
				{
					Id = 21,
					Code = "CONTROL-KEY-789",
					GameId = 8
				},
				new Key
				{
					Id = 22,
					Code = "RE-VILLAGE-KEY-123",
					GameId = 9
				},
				new Key
				{
					Id = 23,
					Code = "RE-VILLAGE-KEY-456",
					GameId = 9
				},
				new Key
				{
					Id = 24,
					Code = "GOW-KEY-123",
					GameId = 10
				},
				new Key
				{
					Id = 25,
					Code = "GOW-KEY-456",
					GameId = 10
				},
				new Key
				{
					Id = 26,
					Code = "GOW-KEY-789",
					GameId = 10
				},
				new Key
				{
					Id = 27,
					Code = "ELDEN-KEY-123",
					GameId = 11
				},
				new Key
				{
					Id = 28,
					Code = "ELDEN-KEY-456",
					GameId = 11
				},
				new Key
				{
					Id = 29,
					Code = "HOLLOW-KEY-123",
					GameId = 12
				},
				new Key
				{
					Id = 30,
					Code = "HOLLOW-KEY-456",
					GameId = 12
				},
				new Key
				{
					Id = 31,
					Code = "MINECRAFT-KEY-123",
					GameId = 13
				},
				new Key
				{
					Id = 32,
					Code = "TERRARIA-KEY-123",
					GameId = 14
				},
				new Key
				{
					Id = 33,
					Code = "TERRARIA-KEY-456",
					GameId = 14
				},
				new Key
				{
					Id = 34,
					Code = "STARDEW-KEY-123",
					GameId = 15
				},
				new Key
				{
					Id = 35,
					Code = "AMONGUS-KEY-123",
					GameId = 16
				},
				new Key
				{
					Id = 36,
					Code = "LASTOFUS2-KEY-123",
					GameId = 17
				},
				new Key
				{
					Id = 37,
					Code = "LASTOFUS2-KEY-456",
					GameId = 17
				},
				new Key
				{
					Id = 38,
					Code = "GTA5-KEY-123",
					GameId = 18
				},
				new Key
				{
					Id = 39,
					Code = "GTA5-KEY-456",
					GameId = 18
				},
				new Key
				{
					Id = 40,
					Code = "PORTAL2-KEY-123",
					GameId = 19
				},
				new Key
				{
					Id = 41,
					Code = "PORTAL2-KEY-456",
					GameId = 19
				},
				new Key
				{
					Id = 42,
					Code = "SEKIRO-KEY-123",
					GameId = 20
				},
				new Key
				{
					Id = 43,
					Code = "SEKIRO-KEY-456",
					GameId = 20
				},
				new Key
				{
					Id = 44,
					Code = "SEKIRO-KEY-789",
					GameId = 20
				}
			});
		}
	}
	public class CartItem : ViewModelBase
	{
		private int A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Game A;

		public Game Game
		{
			[CompilerGenerated]
			get
			{
				return A;
			}
			[CompilerGenerated]
			set
			{
				A = value;
			}
		}

		public int Quantity
		{
			get
			{
				return this.A;
			}
			set
			{
				this.A = value;
				OnPropertyChanged("Quantity");
				OnPropertyChanged("TotalPrice");
			}
		}

		public decimal TotalPrice => Game.Price * (decimal)Quantity;
	}
	public class Game : ViewModelBase
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class A
		{
			public static readonly A A;

			public static Func<Key, bool> A;

			static A()
			{
				Game.A.A = new A();
			}

			internal bool A(Key P_0)
			{
				return !P_0.IsUsed;
			}
		}

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private decimal m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerable<Key> m_A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string? a;

		public int Id
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public string Title
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public decimal Price
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public virtual IEnumerable<Key> Keys
		{
			[CompilerGenerated]
			get
			{
				return this.m_A;
			}
			[CompilerGenerated]
			set
			{
				this.m_A = value;
			}
		}

		public string? ImagePath
		{
			[CompilerGenerated]
			get
			{
				return a;
			}
			[CompilerGenerated]
			set
			{
				a = value;
			}
		}

		public int KeyCount => Keys.Where((Key P_0) => !P_0.IsUsed).Count();
	}
	public class Key
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int a;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Game A;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool A;

		[Key]
		public int Id
		{
			[CompilerGenerated]
			get
			{
				return this.A;
			}
			[CompilerGenerated]
			set
			{
				this.A = value;
			}
		}

		public string Code
		{
			[CompilerGenerated]
			get
			{
				return this.A;
			}
			[CompilerGenerated]
			set
			{
				this.A = value;
			}
		}

		public int GameId
		{
			[CompilerGenerated]
			get
			{
				return a;
			}
			[CompilerGenerated]
			set
			{
				a = value;
			}
		}

		public virtual Game Game
		{
			[CompilerGenerated]
			get
			{
				return this.A;
			}
			[CompilerGenerated]
			set
			{
				this.A = value;
			}
		}

		public bool IsUsed
		{
			[CompilerGenerated]
			get
			{
				return A;
			}
			[CompilerGenerated]
			set
			{
				A = value;
			}
		}
	}
}
