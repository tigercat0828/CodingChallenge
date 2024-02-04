using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shared;
using System.Collections.Generic;

namespace FallingSand {
    public class FallingSand : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Brush Brush;

        int WindowWidth;
        int WindowHeight;

        private VertexPosition[] viewGridVertex;
        int sandSize;
        int sandRows;
        int sandCols;
        int[][] Sands;
        Color[] SandColors;
        public FallingSand() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Initialize() {
            Window.Title = "Falling Sand";
            

            // game parameter
            SetWindowSize(600, 600);
            SetSandSize(20);
            Brush = new(GraphicsDevice, WindowWidth, WindowHeight);
            
            SandColors = new Color[] {
                new (249,245,240),
                new (235,223,204),
                new (222,202,169),
                new (208,180,133),
                new (195,158,98),
                new (177,135,67),
            };

            sandCols = WindowWidth / sandSize;
            sandRows = WindowHeight / sandSize;
            Brush.SetGridParam(sandRows, sandCols, sandSize);
            CreateSandGrid();

            base.Initialize();
        }
        protected override void Update(GameTime gameTime) {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed) {
                SpawnSand(mouseState.X, mouseState.Y);
            }

            UpdateSand();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);


            for (int i = 0; i < sandRows; i++) {
                for (int j = 0; j < sandCols; j++) {
                    if (Sands[i][j] > 0) {
                        Color color = SandColors[Sands[i][j]];
                        Brush.SetColor(color);
                        Brush.DrawRectangleFill(j * sandSize, i * sandSize, sandSize, sandSize);
                    }
                }
            }
            Brush.SetColor(new Color(50, 50, 50));
            Brush.DrawGrid();

            base.Draw(gameTime);
        }

        private void CreateSandGrid() {

            Sands = new int[sandRows][];
            for (int i = 0; i < sandRows; i++)
                Sands[i] = new int[sandCols];

        }
        private void SpawnSand(int mouseX, int mouseY) {
            int sr = mouseY / sandSize;
            int sc = mouseX / sandSize;
            if (sr >= 0 && sr < sandRows && sc >= 0 && sc < sandCols) {
                if (Sands[sr][sc] == 0) {
                    int pickedColor = Utils.Random(0, SandColors.Length);
                    Sands[sr][sc] = pickedColor;
                }
            }
        }
        private void UpdateSand() {
            int[][] NextGrid = new int[sandRows][];
            for (int i = 0; i < sandRows; i++) NextGrid[i] = new int[sandCols];
            for (int i = 0; i < sandRows; i++) {
                for (int j = 0; j < sandCols; j++) {
                    if (Sands[i][j] != 0) {
                        bool under = (i + 1 < sandRows);
                        bool below = under && Sands[i + 1][j] == 0;
                        bool belowR = under && (j + 1 < sandCols) && Sands[i + 1][j + 1] == 0;
                        bool belowL = under && (j - 1 >= 0) && Sands[i + 1][j - 1] == 0;
                        if (below) {
                            NextGrid[i + 1][j] = Sands[i][j];
                        }
                        else if (belowL) {
                            NextGrid[i + 1][j - 1] = Sands[i][j];
                        }
                        else if (belowR) {
                            NextGrid[i + 1][j + 1] = Sands[i][j];
                        }
                        else {
                            NextGrid[i][j] = Sands[i][j];
                        }
                    }
                }
            }
            Sands = NextGrid;
        }

        public void SetWindowSize(int width, int height) {
            WindowWidth = width;
            WindowHeight = height;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
        }
        private void SetSandSize(int size) {
            sandSize = size;
        }
      
    }
}
