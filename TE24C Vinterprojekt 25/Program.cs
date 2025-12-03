using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Vinter God Jul");
Raylib.ToggleFullscreen();
// Simon Nordlund Magnusson rekommenderade^
Raylib.SetTargetFPS(60);

Texture2D placeholder = Raylib.LoadTexture("placeholder.png");
// hämtar bilden 
Rectangle placeholderrect = new(500, 500, placeholder.Dimensions);
// skapar en rektangel vid 500, 500 med samma dimensioner som bilden
float speed = 8;
// hastighet

List<Vector3> stars = [];
List<Vector2> bullets = [];

Random rand = new Random();
for (int star = 0; star < 5000; star++)
// räknar stjärnor upp till 5000
{
    Vector3 starPos = new(rand.Next(15, 1905), rand.Next(15, 1065), 1 + (float)rand.NextDouble() * 2);
    // 1+ så att ingen står still, NextDouble är likt en float men väljer mellan 0 & 1 och därför behöver man gångra
    stars.Add(starPos);
    // krankhjälp^

    // Raylib.DrawCircle(rand.Next(15, 985), rand.Next(15, 985), 5, Color.White);
    // den övre kommentaren funkariiish 
    // rand.Next() gör så att stjärnorna placeras mellan pixel 15 och pixel 985
    // 15 och 985 gör så att det är 15px mellanrum mellan yttersta stjärnan & bordern
}// Sixten Tamleht hjälpte med Random grejerna & förklarade hur for loopen funkar men jag förstår
int framesSinceLastShot = 0;
int framesBetweenShots = 15;

while (Raylib.WindowShouldClose() == false)
{
    if (Raylib.IsKeyDown(KeyboardKey.W)) placeholderrect.Y -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.A)) placeholderrect.X -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.S)) placeholderrect.Y += speed;
    if (Raylib.IsKeyDown(KeyboardKey.D)) placeholderrect.X += speed;
    framesSinceLastShot++;

    if (Raylib.IsKeyDown(KeyboardKey.Space) && framesSinceLastShot > framesBetweenShots)
    {
        Vector2 pos = new(
            placeholderrect.X + placeholderrect.Width, 
            placeholderrect.Y + placeholderrect.Height / 2
            );
        bullets.Add(pos);
        framesSinceLastShot = 0;
    } // projektil är som en stjärna

    if (placeholderrect.Y < 0)
    {
        float Wdiff = -placeholderrect.Y;
        placeholderrect.Y += Wdiff;
    }
    if (placeholderrect.X < 0)
    {
        float Adiff = -placeholderrect.X;
        placeholderrect.X += Adiff;
    }
    if (placeholderrect.Y + placeholderrect.Height > 1080)
    {
        float Sdiff = placeholderrect.Y + placeholderrect.Height - 1080;
        placeholderrect.Y -= Sdiff;
    }
    if (placeholderrect.X + placeholderrect.Width > 1920)
    {
        float Ddiff = placeholderrect.X + placeholderrect.Width - 1920;
        placeholderrect.X -= Ddiff;
    }// Krank måsvingegrej



    for (int i = 0; i < bullets.Count; i++)
    {
        Vector2 bullet = bullets[i];
        bullet.X+=6;
        bullets[i] = bullet;
    }

    bullets.RemoveAll(b => b.X > 1920);


    Raylib.BeginDrawing();
    // kontrollgrejer, bildinläggning & hastighet kopierade & modifierade från https://github.com/divedconh287/TE24C_Graphics
    Raylib.ClearBackground(Color.Black);
    for (int i = 0; i < stars.Count; i++)
    {
        Vector3 s = stars[i];
        s.Y += s.Z;
        if (s.Y > 1080) s.Y = 0;
        // likt rect^
        stars[i] = s;
        // gör så att sjärnorna åker nedåt

        // hakparentes är till listor
        Raylib.DrawCircle((int)stars[i].X, (int)stars[i].Y, 2, Color.White);
    }//krankhjälp^

    for (int i = 0; i < bullets.Count; i++)
    {
        Raylib.DrawCircle((int)bullets[i].X, (int)bullets[i].Y, 5, Color.Red);
        // hakparentes är till listor
    }//kopierad och modifierad för bullets

    Raylib.DrawTexture(placeholder, (int)placeholderrect.X, (int)placeholderrect.Y, Color.White);
    
    Raylib.EndDrawing();
}
// krank rekommenderade att ha stjärnorna gå långsamt ned som en "starfield effekt" KLAR!
// en fiende är bara en stjärna som slumpar y värde och kommer från andra hållet