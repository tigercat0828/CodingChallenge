using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FallingSand {
    public class SandBoxGame : Game {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Brush Painter;

        int WindowWidth;
        int WindowHeight;

        private VertexPosition[] viewGridVertex;
        int sandSize;
        int sandRows;
        int sandCols;
        int[][] Sands;
        Color[] SandColors;
        public SandBoxGame() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.Title = "Falling Sand";
        }
        public void SetWindowSize(int width, int height) {
            WindowWidth = width;
            WindowHeight = height;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
        }
        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Initialize() {

            base.Initialize();
            // game parameter
            int width = 600;
            int height = 600;
            sandSize = 20;

            SetWindowSize(width, height);
            Painter = new(GraphicsDevice, width, height);

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
            CreateViewGrid();
            CreateSandGrid();
        }
        protected override void Update(GameTime gameTime) {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed) { 
                SpawnSand( mouseState.X, mouseState.Y);
            }

            UpdateSand();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

          
            for (int i = 0; i < sandRows; i++) {
                for (int j = 0; j < sandCols; j++) {
                    if (Sands[i][j] >0) {
                        Color color = SandColors[Sands[i][j]];
                        Painter.SetColor(color);
                        Painter.DrawRectangleFill(j * sandSize, i * sandSize, sandSize, sandSize);
                    }
                }
            }
            Painter.SetColor(new Color(50,50,50));
            DrawGrid();

            base.Draw(gameTime);
        }

        private void CreateViewGrid() {
            List<VertexPosition> vertices = new();
            for (int i = 0; i < sandRows; i++) {
                vertices.Add(new(new Vector3(0, i * sandSize, 0)));
                vertices.Add(new(new Vector3(WindowWidth, i * sandSize, 0)));
            }

            for (int i = 0; i < sandCols; i++) {

                vertices.Add(new(new Vector3(i * sandSize, 0, 0)));
                vertices.Add(new(new Vector3(i * sandSize, WindowHeight, 0)));
            }
            viewGridVertex = vertices.ToArray();
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
                        bool below = under && Sands[i + 1][j]== 0;
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
        private void DrawGrid() {
            Painter.DrawLineList(viewGridVertex);
        }
    }
}
