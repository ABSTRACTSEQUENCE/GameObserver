<!DOCTYPE html>
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

<body class="bg-dark text-light" background="Pictures\Background\bg.jpg">
    <style>
        .game {
            margin-top: 3%;
            display: flex;
            padding: 10px;
            flex-direction: column;
        }
        
    </style>
    <div class="container" id='profile'>
        <?
        include 'script.php';
        $games = get_games();
        $genre = null;
        if (isset($_GET["genre"]))
            $genre = get_genre((int) $_GET["genre"]);
        ?>
        <div class="container-fluid text-center" id="main">
            <div class="row">
                <div class="col col_menu"><a href="genres.php">Жанры</a></div>
                <?
        if (empty($_COOKIE["name"])) {
            echo (
                "<div class='col'><img src='Pictures/icon.jpg' >
                <p>Гость( Не зарегестрирован )</p></div>");
        } else{
            echo (
                "<div class='col' id= 'user'><a href='profile.php'><img src='Pictures/icon.jpg' id='user_img'></a>
                Пользователь: <a href='profile.php'>" . $_COOKIE['name'] . "</a></div>");
        }  
        ?>
                <div class="col col_menu"><a href="reg.php">Регистрация/Вход</a></div>
            </div>
        </div>
        </div>
        <div class="container text-center">
            <div class="row games">
                <?
                //$games = get_games();
                if(isset($genre)){ echo ("<div class='col'><a href = 'index.php'>Сбросить жанры</a></div><h2>Игры жанра " . $genre->Name . "</h2>"); }
                if (count($games) > 0) {

                    foreach ($games as $i) {
                        $desired_length = 1000;
                        if (strlen($i->Description) > $desired_length) {
                            $i->Description = str_split($i->Description, $desired_length)[0] . "...";
                        }
                        if (isset($genre)) {
                            if (!genreOf($i->Id, $genre->Id))
                                continue;
                            else
                                echo ("<div class='col game'><a href='game.php?game=" . $i->Id . "'><img class = preview_pic src= 'data:image/png;base64,".$i->Preview."'/>></a><div class = 'description'><span class = game_name>" . $i->Name . "</span>" . $i->Description . "</div></div>");
                        }
                        else {
                            echo ("<div class='col game'><a href='game.php?game=" . $i->Id . "'><img class = 'preview_pic' src= 'data:image/png;base64,".$i->Preview."'/></a><div class = 'description'><span class = game_name>" . $i->Name . "</span><p>" . $i->Description . "</p></div></div>");
                        }
                        //echo("<div class='col game'><a href='game.php?game=".$i->Id."'><img class = preview_pic col src='/Pictures/Previews/".$i->Name."/".$i->Name.".png'/></a><div class = 'description'><span class = game_name>".$i->Name."</span><p>".$i->Description."</p></div></div>"); 
                    }
                } else
                    echo ("<h1>В базе данных пока нет ни одной игры. Добавьте игры через AdminPanel</h1>");
                ?>
            </div>
            <script src="script.php"></script>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
                integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
                crossorigin="anonymous"></script>
</body>

</html>