using System;

namespace ButtonTest {
    public class GameManager {
        private readonly UIManager UIs = new();
        public GameManager() {
            UIs.AddButton(new(100, 100)).OnClick += Action1;
            UIs.AddButton(new(250, 100)).OnClick += ActionM1;
            UIs.AddButton(new(400, 100)).OnClick += Action2;
            UIs.AddButton(new(550, 100)).OnClick += ActionM2;
        }
        public void Action1(object sender, EventArgs eventArgs) {
            UIs.Counter++;
        }
        public void ActionM1(object sender, EventArgs eventArgs) {
            UIs.Counter--;
        }
        public void Action2(object sender, EventArgs eventArgs) {
            UIs.Counter += 2;
        }
        public void ActionM2(object sender, EventArgs eventArgs) {
            UIs.Counter -= 2;
        }
        public void Update() {
            UIs.Update();
        }
        public void Draw() {
            UIs.Draw();
        }
    }
}