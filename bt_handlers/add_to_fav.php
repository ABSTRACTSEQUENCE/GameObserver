<?
include("../script.php");
$user = get_user($_COOKIE["uid"]);
$game = get_game($_POST['gameId']);
$game->Users_Id = $user->Id;
$stmt = sqlsrv_query($connection, "SELECT * FROM UsersGames WHERE Users_Id =".$user->Id);
if(!sqlsrv_has_rows($stmt)){
    $stmt = 
    "INSERT INTO UsersGames VALUES (".$user->Id.",".$game->Id.")";
    if(!sqlsrv_query($connection, $stmt)) die(var_dump(sqlsrv_errors()));
}
header("location:../game.php?game=".$game->Id);
