<?
include("script.php");

$game = get_games()[0];
$pic = base64_encode($game->Preview);
//$pic = imagecreatefromstring($game->Preview);
echo("<img src='data:image/png;base64,$pic'>")
?>
