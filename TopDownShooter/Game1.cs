using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooter {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        GameManager Manager;
        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.Content = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            
            Globals.Bound = new(1024, 768);
            _graphics.PreferredBackBufferWidth = Globals.Bound.X;
            _graphics.PreferredBackBufferHeight = Globals.Bound.Y;
            _graphics.ApplyChanges();
            Manager = new();
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;

        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Globals.Update(gameTime);
            Manager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            Manager.Draw();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
