using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shared;
using System.Threading.Tasks.Dataflow;

namespace P5tranplant {
    public class Game1 : Game {
        private GraphicsDeviceManager m_graphics;
        private SpriteBatch m_spriteBatch;
        private Brush Brush;
        int m_WindowWidth;
        int m_WindowHeight;
        
        public Game1() {
            m_graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void LoadContent() {
            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            SetWindowTitle("test");
            SetWindowSize(800,800); 
            Brush = new(GraphicsDevice, m_WindowWidth, m_WindowHeight);
            Brush.SetDrawMode(RectMode.Center);
            base.Initialize();
        }
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        float degree =0;
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            float angle = degree++ * 3.14f/ 180;
            Brush.Translate(m_WindowWidth/2, m_WindowHeight/2);
            Brush.Rotate(angle, Vector3.UnitZ);
            Brush.ApplyTransform();
            Brush.DrawRectangleFill(0, 0, 200 ,200);
            
            m_spriteBatch.Begin();

            m_spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void SetWindowSize(int width , int height) {
            m_WindowWidth = width; 
            m_WindowHeight = height; 
            m_graphics.PreferredBackBufferWidth = m_WindowWidth;
            m_graphics.PreferredBackBufferHeight = m_WindowHeight;
            m_graphics.ApplyChanges();
        }
        protected void SetWindowTitle(string title) {
            Window.Title = title;
        }
    }
}
