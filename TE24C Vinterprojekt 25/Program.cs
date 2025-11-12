using Raylib_cs;

Raylib.InitWindow(1000, 1000, "Vinter God Jul");

Texture2D placeholder = Raylib.LoadTexture("placeholder.png");
// hämtar bilden 
Rectangle placeholderrect = new(260, 500, placeholder.Dimensions);
// skapar en rektangel vid 500, 500 med samma dimensioner som bilden
float speed = 4;
// hastighet

Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Black);
    Random rand = new Random();
for (int star = 0; star < 50; star++)
// räknar stjärnor upp till 50 
{
    Raylib.DrawCircle(rand.Next(15, 985), rand.Next(15, 985), 5, Color.White);
    // rand.Next() gör så att stjärnorna placeras mellan pixel 15 och pixel 985
    // 15 och 985 gör så att det är 15px mellanrum mellan yttersta stjärnan & bordern
}// Sixten Tamleht hjälpte med Random grejerna & förklarade hur for loopen funkar men jag förstår

Raylib.DrawTexture(placeholder,(int)placeholderrect.X,(int)placeholderrect.Y,Color.White);

Raylib.EndDrawing();

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    if (Raylib.IsKeyDown(KeyboardKey.Right)) placeholderrect.X += speed;
    if (Raylib.IsKeyDown(KeyboardKey.Left)) placeholderrect.X -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.Down)) placeholderrect.Y += speed;
    if (Raylib.IsKeyDown(KeyboardKey.Up)) placeholderrect.Y -= speed;

    if (placeholderrect.X < 0) placeholderrect.X += speed;
    if (placeholderrect.X + placeholderrect.Width > 1000) placeholderrect.X -= speed;
    if (placeholderrect.Y < 0) placeholderrect.Y += speed;
    if (placeholderrect.Y + placeholderrect.Height > 1000) placeholderrect.Y -= speed;
    // kontrollgrejer, bildinläggning & hastighet kopierade & modifierade från github.com/divedconh287/TE24C_Graphics
    Raylib.EndDrawing();
}

// vet inte vad som händer måste fråga Krank
