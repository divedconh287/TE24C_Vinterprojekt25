using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(1000, 1000, "Vinter God Jul");
Raylib.SetTargetFPS(60);

Texture2D placeholder = Raylib.LoadTexture("placeholder.png");
// hämtar bilden 
Rectangle placeholderrect = new(260, 500, placeholder.Dimensions);
// skapar en rektangel vid 500, 500 med samma dimensioner som bilden
float speed = 4;
// hastighet

List<Vector2> stars = [];

Random rand = new Random();
    for (int star = 0; star < 50; star++)
    // räknar stjärnor upp till 50 
    {
        Vector2 starPos = new(rand.Next(15,985), rand.Next(15,985));
        stars.Add(starPos);
        // krankhjälp^

        // Raylib.DrawCircle(rand.Next(15, 985), rand.Next(15, 985), 5, Color.White);
        // den övre kommentaren funkariiish 
        // rand.Next() gör så att stjärnorna placeras mellan pixel 15 och pixel 985
        // 15 och 985 gör så att det är 15px mellanrum mellan yttersta stjärnan & bordern
    }// Sixten Tamleht hjälpte med Random grejerna & förklarade hur for loopen funkar men jag förstår


while (Raylib.WindowShouldClose() == false)
{
    if (Raylib.IsKeyDown(KeyboardKey.W)) placeholderrect.Y -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.A)) placeholderrect.X -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.S)) placeholderrect.Y += speed;
    if (Raylib.IsKeyDown(KeyboardKey.D)) placeholderrect.X += speed;

    if (placeholderrect.Y < 0) placeholderrect.Y += speed;
    if (placeholderrect.X + placeholderrect.Width > 1000) placeholderrect.X -= speed;
    if (placeholderrect.Y + placeholderrect.Height > 1000) placeholderrect.Y -= speed;
    if (placeholderrect.X < 0) placeholderrect.X += speed;


    Raylib.BeginDrawing();
    // kontrollgrejer, bildinläggning & hastighet kopierade & modifierade från github.com/divedconh287/TE24C_Graphics
    Raylib.ClearBackground(Color.Black);
    for (int i = 0; i < stars.Count; i++)
    {
        Raylib.DrawCircleV(stars[i], 5, Color.White);
    }//krankhjälp^

    Raylib.DrawTexture(placeholder, (int)placeholderrect.X, (int)placeholderrect.Y, Color.White);


    Raylib.EndDrawing();
}

// krank rekommenderade att ha stjärnorna gå långsamt ned som en "starfield effekt"
