<?
include_once("script.php");
$user = get_user((int)$_GET["uid"]);
$favs = array();
if(!empty($_POST)){
    $stmt = sqlsrv_query($connection, "DELETE FROM UsersGames WHERE Users_Id = ".$user->Id." AND Game_Id = ".$_POST['del']);
}
$stmt = sqlsrv_query($connection,"SELECT Game_Id FROM UsersGames WHERE Users_Id = ".$user->Id);
while($i = sqlsrv_fetch_array($stmt,SQLSRV_FETCH_ASSOC )){
    $game = get_game($i['Game_Id']);
    array_push($favs, $game);
}
//array_push($games, get_game(sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)["Id"]));
?>

<html>
<head>
    <meta charset="utf-8">
    <title>Game Observer</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="style.css">
    <link href="favicon.ico" rel="icon">
</head>
<body class="bg-dark text-light">
    <div class="d-flex flex-column align-items-center">
        <div><a href="index.php"><img src="logo_white.png"></a></div>
        <div class='rounded-3 p-3'>Избранные игры <?
        echo "<a class = 'align-self-center p-2 mt-3' href = profile.php?User=".$user->Id.">".$user->Name."</a>
        <div class=' d-flex flex-column'>
        <img class = 'ava' src = ".$user->Avatar.">
        
        </div>"?>
        </div>
    <?
    if(!empty($favs))
    foreach($favs as $fav){
            $desired_length = 1000;
            if (strlen($fav->Description) > $desired_length) {
                $fav->Description = str_split($fav->Description, $desired_length)[0] . "...";
            }
            echo (
            "<div class='game element p-5' style='max-width:1000px;border-radius:20px'>
            <a href='game.php?game=" . $fav->Id . "'>
            <img class = preview_pic src= 'data:image/png;base64,".$fav->Preview."'/>
            </a><div class = 'description'>
            <span class = game_name>" . $fav->Name . "</span>" . $fav->Description . "</div>
            <form method='POST'>
            <button name='del' class = 'bg-dark text-white mt-3 border-0' style='opacity:96%' value=".$fav->Id.">Убрать из избранного</button>
            </form>
            </div>");
    }
    else echo "<h1>Избранных игр нет</h1>"
    ?>
    </div>
</body>
</html>