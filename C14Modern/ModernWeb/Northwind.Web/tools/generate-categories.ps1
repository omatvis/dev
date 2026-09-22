# Generates C:\projects\dev\C14Modern\ModernWeb\Northwind.Web\wwwroot\categories.jpeg (300x200)

$dest = "C:\projects\dev\C14Modern\ModernWeb\Northwind.Web\wwwroot\categories.jpeg"
$width = 300
$height = 200

# Load drawing assembly (Windows)
try { Add-Type -AssemblyName System.Drawing -ErrorAction Stop } catch { Add-Type -AssemblyName System.Drawing.Common -ErrorAction SilentlyContinue }

$bmp = New-Object System.Drawing.Bitmap $width, $height
$g = [System.Drawing.Graphics]::FromImage($bmp)
$g.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
$g.Clear([System.Drawing.Color]::FromArgb(250,250,250))

# Title
$titleFont = New-Object System.Drawing.Font "Segoe UI", 16, ([System.Drawing.FontStyle]::Bold)
$titleBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(30,30,30))
$g.DrawString("Categories", $titleFont, $titleBrush, 10, 8)

# Category boxes
$categories = @(
    @{Name='Beverages'; Color = [System.Drawing.Color]::FromArgb(52,152,219)},
    @{Name='Condiments'; Color = [System.Drawing.Color]::FromArgb(46,204,113)},
    @{Name='Confections'; Color = [System.Drawing.Color]::FromArgb(155,89,182)},
    @{Name='Dairy Products'; Color = [System.Drawing.Color]::FromArgb(241,196,15)},
    @{Name='Grains/Cereals'; Color = [System.Drawing.Color]::FromArgb(231,76,60)}
)

$boxX = 10
$boxY = 45
$boxW = 140
$boxH = 26
$gap = 6
$font = New-Object System.Drawing.Font "Segoe UI", 10
$whiteBrush = [System.Drawing.Brushes]::White

for ($i = 0; $i -lt $categories.Count; $i++) {
    $c = $categories[$i]
    $y = $boxY + ($boxH + $gap) * $i
    $rect = New-Object System.Drawing.Rectangle $boxX, $y, $boxW, $boxH
    $fillBrush = New-Object System.Drawing.SolidBrush $c.Color
    $g.FillRectangle($fillBrush, $rect)
    $g.DrawString($c.Name, $font, $whiteBrush, $rect.X + 8, $rect.Y + 4)
    $fillBrush.Dispose()
}

# Small legend on the right (colored circles)
$legendX = 170
$legendY = 50
$circleSize = 18
$textBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(40,40,40))
for ($i = 0; $i -lt $categories.Count; $i++) {
    $c = $categories[$i]
    $y = $legendY + ($circleSize + 8) * $i
    $circleRect = New-Object System.Drawing.Rectangle $legendX, $y, $circleSize, $circleSize
    $brush = New-Object System.Drawing.SolidBrush $c.Color
    $g.FillEllipse($brush, $circleRect)
    $g.DrawString($c.Name, $font, $textBrush, $legendX + $circleSize + 8, $y + 1)
    $brush.Dispose()
}

# Save as JPEG
$jpegFormat = [System.Drawing.Imaging.ImageFormat]::Jpeg
# Ensure target directory exists
$dir = [System.IO.Path]::GetDirectoryName($dest)
if (-not (Test-Path $dir)) { New-Item -ItemType Directory -Path $dir | Out-Null }

$encoderParams = New-Object System.Drawing.Imaging.EncoderParameters 1
$encoderParams.Param[0] = New-Object System.Drawing.Imaging.EncoderParameter ([System.Drawing.Imaging.Encoder]::Quality, 90)
$codec = [System.Drawing.Imaging.ImageCodecInfo]::GetImageEncoders() | Where-Object { $_.MimeType -eq "image/jpeg" }
$bmp.Save($dest, $codec, $encoderParams)

# Cleanup
$g.Dispose()
$bmp.Dispose()
$titleFont.Dispose()
$titleBrush.Dispose()
$font.Dispose()
$textBrush.Dispose()

Write-Output "Saved: $dest"