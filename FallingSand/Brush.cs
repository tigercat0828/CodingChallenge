using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FallingSand {
    public class Brush {
        private readonly BasicEffect basicEffectVertexPositionOnly;
        private readonly BasicEffect basicEffectVertexPositionColor;
        private readonly GraphicsDevice graphicsDevice;
        public Brush(GraphicsDevice device, int width, int height) {
            graphicsDevice = device;
            
            basicEffectVertexPositionOnly = new(graphicsDevice) {
                View = Matrix.CreateLookAt(new Vector3(0, 0, 1), Vector3.Zero, Vector3.Up),
                Projection = Matrix.CreateOrthographicOffCenter(0, width, height, 0, 0, 1)
            };

            basicEffectVertexPositionColor = new(graphicsDevice) {
                VertexColorEnabled = true,
                View = Matrix.CreateLookAt(new Vector3(0, 0, 1), Vector3.Zero, Vector3.Up),
                Projection = Matrix.CreateOrthographicOffCenter(0, width, height, 0, 0, 1)
            };
        }
        public void SetColor(Color color) {
            basicEffectVertexPositionOnly.DiffuseColor = color.ToVector3();
        }
        public void DrawLine(int x1, int y1, int x2, int y2) {
            VertexPosition[] vertices = new VertexPosition[2] {
                new (new Vector3(x1, y1, 0)),
                new (new Vector3(x2, y2, 0))
            };
            basicEffectVertexPositionOnly.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertices, 0, 1);
        }

        public void DrawLineList(VertexPosition[] vertices) {
            basicEffectVertexPositionOnly.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertices, 0, vertices.Length/2);
        }

        public void DrawRectangleFill(int x, int y, int w, int h) {
            
            VertexPosition[] vertices = new VertexPosition[4] {
                new (new Vector3(x, y, 0)),
                new (new Vector3(x + w, y, 0)),
                new (new Vector3(x, y + h, 0)),
                new (new Vector3(x + w, y + h, 0))
            };

            basicEffectVertexPositionOnly.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, vertices, 0, 2);
        }
        public void DrawRectangleOutline(int x, int y, int w, int h) {
            VertexPosition[] vertices = new VertexPosition[] {
                new (new Vector3(x, y, 0)),
                new (new Vector3(x + w, y, 0)),
                new (new Vector3(x + w, y + h, 0)),
                new (new Vector3(x, y + h, 0)),
                new (new Vector3(x, y, 0)),
            };
            basicEffectVertexPositionOnly.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, vertices, 0, 4);
        }
        public void DrawCircleOutline(int x, int y, int radius, int segments = 32) {
            VertexPosition[] vertices = new VertexPosition[segments + 1];

            for (int i = 0; i <= segments; i++) {
                float angle = 2 * MathF.PI * i / segments;
                float xPos = x + radius * MathF.Cos(angle);
                float yPos = y + radius * MathF.Sin(angle);

                vertices[i] = new VertexPosition(new Vector3(xPos, yPos, 0));
            }
            basicEffectVertexPositionOnly.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, vertices, 0, segments);
        }
        public void DrawCircleFill(int x, int y, int radius, int segments = 32) {

            VertexPosition[] vertices = new VertexPosition[segments * 3];

            for (int i = 0; i < segments; i++) {
                float angle1 = 2 * MathF.PI * i / segments;
                float angle2 = 2 * MathF.PI * (i + 1) / segments;

                float xPos1 = x + radius * MathF.Cos(angle1);
                float yPos1 = y + radius * MathF.Sin(angle1);

                float xPos2 = x + radius * MathF.Cos(angle2);
                float yPos2 = y + radius * MathF.Sin(angle2);

                vertices[i * 3] = new VertexPosition(new Vector3(x, y, 0));
                vertices[i * 3 + 1] = new VertexPosition(new Vector3(xPos1, yPos1, 0));
                vertices[i * 3 + 2] = new VertexPosition(new Vector3(xPos2, yPos2, 0));
            }

            basicEffectVertexPositionOnly.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, segments);
        }

    }
}

//public void DrawLine(int x1, int y1, int x2, int y2, Color color, int thickness) {

//    Vector2 direction = new(x2 - x1, y2 - y1);
//    direction.Normalize();

//    Vector2 perpendicular = new Vector2(-direction.Y, direction.X) * thickness / 2f;

//    VertexPositionColor[] vertices = new VertexPositionColor[4];

//    vertices[0] = new VertexPositionColor(new Vector3(x1 + perpendicular.X, y1 + perpendicular.Y, 0), color);
//    vertices[1] = new VertexPositionColor(new Vector3(x2 + perpendicular.X, y2 + perpendicular.Y, 0), color);
//    vertices[2] = new VertexPositionColor(new Vector3(x2 - perpendicular.X, y2 - perpendicular.Y, 0), color);
//    vertices[3] = new VertexPositionColor(new Vector3(x1 - perpendicular.X, y1 - perpendicular.Y, 0), color);

//    basicEffect.CurrentTechnique.Passes[0].Apply();
//    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, vertices, 0, 2);
//}