<?

use function PHPSTORM_META\type;

include "script.php";
$game = get_game($_GET['game']);
$user = get_user();

$comments = get_comments($game->Id);

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
    .col{
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

    } */
    #screenshot_section{
        margin-top: 2%;
        margin-bottom: 2%;
    }
</style>
<body class="bg-dark text-light" background="Pictures\Background\bg.jpg">
<div class="container" id = 'profile'>
            <?
            if(isset($_COOKIE["name"])) echo("<a href='profile.php'><img src='Pictures/icon.jpg' id='user_img'></a>");
            else echo("<img src='Pictures/icon.jpg' id='user_img'>");

            ?>
            
            <div class="col" <?
            if(empty($_COOKIE["name"])) {echo("id= 'user_guest'>Гость( Не зарегестрирован )");
            }
            else echo("id= 'user'>Пользователь: <a href='profile.php'>".$_COOKIE['name']."</a>");
                ?>
            </div>
            <div class="col button" id="back"><a href="index.php">Вернуться</a></div>
        </div>
    <div class="container" id="container">
        <div class="row">
            <div id="preview"><?echo("<img class = 'preview_pic' src='data:image/png;base64,".$game->Preview."'/>")?></div>
            <div class="col" id = "description_section"><?echo $game->Name?><br>
                <?echo($game->Description)?>
                </div>
                <div class="row" id="screenshot_section">
                    Скриншоты
                    <p>
                        <?
                        $screenshots = get_screenshots($game->Id);
                            foreach($screenshots as $screenshot){
                                //$screenshot = base64_encode($screenshot);
                                echo("<img class = 'screenshot' src = 'data:image/png;base64,".base64_encode($screenshot)."'>");
                            };
                        ?>
                    </p>
                </div>
                <?
                if($game->Steam != "") echo("
                <div class = 'col' id = 'steamlink'>Если вам понравилась игра, поддержите разработчка, купив её в стиме
                    <p><a href=$game->Steam>".$game->Steam."</a></p>
                </div>")
                ?>
        <div class="row">
            <div class="col">Жанры:
            <?
            foreach($rel as $i){
                foreach($i as $j) echo $j.", ";
            }
            ?>
            </div>
        </div>
        <?
        
        if(isset($game->Torrent)){
            $filename = "Torrents/".$game->Name.".torrent";
            $stream = fopen($filename, 'w');
            fwrite($stream,$game->Torrent);
            fclose($stream);
            echo(
            "<div class='col'>
            <a href = '".$filename."'>
            Скачать торрент</a>
            </div>");
    }
        ?>
        </div>
        <div class="row" style="display: flex; flex-flow:column;">
            <div class="container row" id="comment_section">
                <div class="row">Коментарии</div>
            <form method="POST" action="bt_handlers/post comment.php" id="form">
                <textarea name = "text" <?if(!isset($_COOKIE['name'])) echo("disabled placeholder='Войдите на сайт, если хотите прокомментировать' style='background: #f2f2f2;'");?> rows="5" id="commentInput"></textarea>
                <button id='bt_ok' class="button" name="game" value = '<?echo $game->Id?>' type = submit<?if(!isset($_COOKIE['name']))echo(' disabled')?>>Отправить</button>
            </form>

        </div>
            <div class="col comments w-1">
                    <?
                    $no_comments = true;
                    if($comments){/////
                        foreach($comments as $i){
                            if($i['GameId'] == $game->Id){
                                $no_comments= false;
                            echo(
                                $i['Username']
                                ." <p class='col comment'>".$i["Text"]//."</div>"
                            );
                            echo("</p>");
                            if(isset($_COOKIE['name'])){
                                if($_COOKIE["name"] == "admin") 
                                echo("<button class = 'comment_del button' onclick = 'handler(".$i['CommentId'].",".$game->Id.")'>Удалить</button>");
                            }
                        }
                        }
                    }
                    if ($no_comments) echo("<h2>Коментариев нет</h2>");
                    ?>
                    <script>
                        function handler(id, game_id){
                            window.location.replace('bt_handlers/delete_comment.php?id='+id+"&gameId="+game_id)
                        }
                    </script>
                </div>
            </div>
    </div>
</body>