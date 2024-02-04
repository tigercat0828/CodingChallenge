

namespace ButtonTest; 
public class Globals {
    public static ContentManager Content { get; set; }  
    public static SpriteBatch SpriteBatch { get; set; }
    public static MouseState MouseState { get; set; }
    public static MouseState LastMouseState { get; set; }
    public static bool LeftButtonClicked { get; set; }
    public static Rectangle MouseCursor { get; set; }
    public static void Update() {
        LastMouseState = MouseState; 
        MouseState = Mouse.GetState();

        LeftButtonClicked = (MouseState.LeftButton == ButtonState.Pressed) && (LastMouseState.LeftButton == ButtonState.Released);
        MouseCursor = new(MouseState.Position, new(1, 1));    
    }
}
