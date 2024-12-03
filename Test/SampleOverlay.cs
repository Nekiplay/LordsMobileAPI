using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ClickableTransparentOverlay;
    using Coroutine;
    using ImGuiNET;
    using LordsMobileAPI;
    using Process.NET.Memory;
    using Vortice.Mathematics;

    /// <summary>
    /// Render Loop and Logic Loop are synchronized.
    /// </summary>
    internal class SampleOverlay : Overlay
    {
        private int data;
        private string data2;
        private bool isRunning = true;
        private Event myevent = new Event();
        private ActiveCoroutine myRoutine1;
        private ActiveCoroutine myRoutine2;

        Process[] game = null;
        LordsMobile lordsMobile = null;
        public SampleOverlay()
        {
            myRoutine1 = CoroutineHandler.Start(TickServiceAsync(), name: "MyRoutine-1");
            myRoutine2 = CoroutineHandler.Start(EventServiceAsync(), name: "MyRoutine-2");

            game = Process.GetProcessesByName("Lords Mobile");
            if (game.Length == 1)
            {
                lordsMobile = new LordsMobile(game[0], ofsetts: new OffsetsSteam());
            }
            else if (game.Length == 0)
            {
                game = Process.GetProcessesByName("Lords Mobile PC");
                if (game.Length == 1)
                {
                    lordsMobile = new LordsMobile(game[0], ofsetts: new OffsetsPC());
                }
            }
        }

        private IEnumerator<Wait> TickServiceAsync()
        {
            int counter = 0;
            while (true)
            {
                counter++;
                yield return new Wait(3);
                this.data = counter;
            }
        }

        private IEnumerator<Wait> EventServiceAsync()
        {
            int counter = 0;
            data2 = "Initializing Event Routine";
            while (true)
            {
                yield return new Wait(myevent);
                data2 = $"Event Raised x {++counter}";
            }
        }
        bool first = false;
        protected override void Render()
        {
            // Render
            Size = new System.Drawing.Size(1680, 1050);
            CoroutineHandler.Tick(ImGui.GetIO().DeltaTime);
            if (data % 5 == 1)
            {
                CoroutineHandler.RaiseEvent(myevent);
            }
            if (lordsMobile != null)
            {
                ImGui.Begin("Neki_play Engine for Lords Mobile", ref isRunning, ImGuiWindowFlags.AlwaysAutoResize);
                ImGui.Text("Power: " + lordsMobile.user.power);
                ImGui.Text("Gems: " + lordsMobile.user.gems);
                ImGui.Text("Stamina: " + lordsMobile.user.stamina);
                ImGui.Text("Energy: " + lordsMobile.user.energy);
                ImGui.Separator();
                ImGui.Text("Gold: " + Math.Round(lordsMobile.resources.gold, 0));
                ImGui.Text("Ore: " + Math.Round(lordsMobile.resources.ore, 0));
                ImGui.Text("Stone: " + Math.Round(lordsMobile.resources.stone, 0));
                ImGui.Text("Wood: " + Math.Round(lordsMobile.resources.wood, 0));
                ImGui.Text("Food: " + Math.Round(lordsMobile.resources.food, 0));
                ImGui.End();
                if (!isRunning)
                {
                    Close();
                }
            }
        }
    }
}
