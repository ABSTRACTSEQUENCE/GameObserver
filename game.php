<?

include "script.php";
$game = get_game($_GET['game']);
if(isset($_COOKIE["uid"]))
    $user = get_user($_COOKIE["uid"]);

$comments = get_comments();

$stmt = sqlsrv_query($connection, 
"SELECT Genres.Name AS 'Genre'
FROM GenreGames, Games, Genres 
WHERE Game_Id = ".$game->Id." 
AND Games.Id = ".$game->Id." 
AND Genres.Id = GenreGames.Genre_Id;");

$rel = array();
while($i=sqlsrv_fetch_array($stmt,SQLSRV_FETCH_ASSOC)){
    array_push($rel, $i);
}

?>
<!DOCTYPE html>
<head>
    <link href="favicon.ico" rel="icon" >
    <meta charset="utf-8">
    <title><?echo $game->Name?></title> 
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="style.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</head>
<style>
    #top_bar{
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    align-content: center;
    align-items: center;
}
    #description{
        background-color: #212529;
    }
    .comment{
            
    }
    #user_guest{
        background-color: #212529;
    }
    /*.col{
        margin-top: 11px;
    }
    #container{
        display: flex;
        margin-top: 3%;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }
    div{
        background-color: #212529;
        border-radius: 40px;
        padding: 10px;
        padding-inline: 47px;
        margin-top:11px;
    }
    #commentInput{
        border-radius: 20px;
        min-width: 700px
    }   
    #comment_section{
        display: flex;
        flex-direction: column;
        align-content: center;
        justify-content: center;
        align-items: center;
    }
    #bt_ok{
        margin-top: 4%;
    }
    #back{
        width: 15%;
        
    }
    #form{
        display: flex;
        flex-flow: column;
        justify-content: center;
        align-items: center;
    }
    #preview{
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .comments{
        background-color: #212529;
        color: white;
        padding: 1%;
        display: flex;
        justify-content: center;
        margin-top:3%;
        flex-flow: column;
    }
    .comment{
        min-width: 195px;
        min-height: 63px;
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .row{
        justify-content: center;
    }
    .screenshot{
        max-width: 28%;
        margin-right: 5%;
    }
    /* .screenshot:hover{
        position: absolute;
        max-width: 57%;
        top: 50%;
        left: 16%;

    } 
    #screenshot_section{
        margin-top: 2%;
        margin-bottom: 2%;
    }*/
</style>
<body class="bg-dark text-light">
    <div id = 'top_bar' class='m-3'>
    <div><a href="index.php"><img src="logo_white.png"></a></div>
    <div class="element d-flex align-items-center text-center flex-column p-3" style="border-radius: 20px">
            <?
            if(isset($user))
            if($user->Avatar) echo("<a href='profile.php'><img class='mb-3' style='max-width:250px; border-radius:20px;' src= $user->Avatar id='user_img'></a>");
            else echo("<img src='Pictures/icon.jpg' id='user_img'>");
            ?>
            
            <div <?
            if(!isset($user)) {echo("class='m-3' '>Гость( Не зарегестрирован )");
            }
            else echo(">Пользователь: <a href='profile.php'>".$user->Name."</a>");
                ?>
            <div class="button" id="back"><a href="index.php">Вернуться</a></div>
            </div>
    </div>
        </div>
        <div class="d-flex flex-column align-items-center text-center">
            <div id="preview" class="m-3"><?echo("<img class = 'preview_pic' src='data:image/png;base64,".$game->Preview."'/>")?></div>
            <div style="margin-left:10%; margin-right:10%;" class="element mt-3 mb-3 p-4 text-center rounded-3" ><?echo $game->Name?><br>
                <?echo($game->Description)?>
                </div>
                <div class="element text-nowrap align-items-center text-center rounded-3">
                    Скриншоты
                    <p>
                        <?
                        $screenshots = get_screenshots($game->Id);
                            foreach($screenshots as $screenshot){
                                //$screenshot = base64_encode($screenshot);
                                echo("<img class = 'screenshot mt-1 me-3 ms-3' src = 'data:image/png;base64,".base64_encode($screenshot)."'>");
                            };
                        ?>
                    </p>
                </div>
                <?
                if($game->Steam != "") echo("
                <div class = id = 'steamlink'>Если вам понравилась игра, поддержите разработчка, купив её в стиме
                    <p><a href=$game->Steam>".$game->Steam."</a></p>
                </div>")
                ?>
                <div class="d-flex flex-row align-items-center justify-content-between">
            <div class="element p-3 mt-3 rounded-3">Жанры:
            <?
            foreach($rel as $i){
                foreach($i as $j) echo $j.", ";
            }
            ?>
            </div>
            <form method = 'POST' action="bt_handlers\add_to_fav.php" name = 'fav'>
                <?
                $stmt =sqlsrv_query($connection,"SELECT * FROM UsersGames WHERE Users_Id =".$user->Id);
                $fav = sqlsrv_has_rows($stmt);
                ?>
            <button <?if($fav) echo "disabled style = 'color:gray !important'";?> class = "element text-light">
                <?
                if($fav) echo("В избранном");
                else echo("В избранное");
                ?>
                </button>
            <input name="gameId" hidden value="<?echo$game->Id?>" >
            </form>
        </div>
      
        <?
        
        if(isset($game->Torrent)){
            $filename = "Torrents/".$game->Name.".torrent";
            $stream = fopen($filename, 'w');
            fwrite($stream,$game->Torrent);
            fclose($stream);
            echo(
            "<div class='element rounded-3 mt-3 p-3'>
            <a href = '".$filename."'>
            Скачать торрент</a>
            </div>");
    }
        ?></div>

<div class="d-flex flex-wrap flex-column mt-3" style= width:500px;><!-- Сделать нормальное отображение элементов -->
        <?
        $no_comments = true;
        if($comments){/////
            
            foreach($comments as $i){
                echo("<div class = 'element text-white rounded-3 d-flex flex-column align-items-center text-center mb-3'>");
                if($i['GameId'] == $game->Id){
                    $no_comments= false;
                echo(
                    "<p class = 'rounded-3 '>".$i['Username']."</p>"
                    ." <p class='comment rounded-3'>".$i["Text"]//."</div>"
                );
                echo("</p>");
                if(isset($user)){
                    if($user->Name == "admin") 
                    echo("<button class = 'comment_del button' onclick = 'handler(".$i['CommentId'].",".$game->Id.")'>Удалить</button>");
                }
                echo("</div>");
            }
            }
        }
        if ($no_comments) echo("<h2 class = 'element'>Коментариев нет</h2>");
        ?>
        
        <div class="bg-dark p-3 mt-3 mb-3 rounded-3 d-flex flex-column text-center align-items-center">
                <p>Коментарии</p>
            <form method="POST" action="bt_handlers/post comment.php" class="d-flex flex-column">
                <textarea style= width:200px; name = "text" <?if(!isset($user)) echo("disabled placeholder='Войдите на сайт, если хотите прокомментировать' style='background: #f2f2f2;'");?> rows="5" id="commentInput"></textarea>
                <button class="mt-2 rounded-3" name="game" value = '<?echo $game->Id?>' type = submit<?if(!isset($user))echo(' disabled')?>>Отправить</button>
            </form>
        </div>
</div>
        
    <script>
            function handler(id, game_id){
                window.location.replace('bt_handlers/delete_comment.php?id='+id+"&gameId="+game_id)
            }
        </script>
</body>