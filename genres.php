<!DOCTYPE html>
<html>
    <head>
    <meta charset="utf-8">
    <title>Game Observer</title> 
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="style.css">
    <link href="favicon.ico" rel="icon" >
    </head>
    <body class="bg-dark text-light">
    <style>
                    .genreList{
                        display: flex;
                        flex-direction: column;
                    }
                    .genreItem{
                        border-color: white;
                        border-width: 2px;
                        border-style: solid;
                        border-radius: 20px;
                        padding: 20px;
                        text-align: center;
                        margin-top: 20px;
                        background-color: #272626;
                        width:651px;
                    }
        </style>
        <div class='d-flex align-items-center flex-column m-3'>
            <div><a href="index.php"><img src="logo_white.png"></a></div>
                <h1>Жанры</h1>
                <div class = 'col genreList'>
                    <?
                    include("script.php");
                    $genres = get_genres();
                    foreach($genres as $genre){
                        echo("<div class='col genreItem' ><a href='index.php?genre=".$genre->Id."'>".$genre->Name."</a></div>");
                    }
                    ?>
                    </div>
        </div>
    </body>
</html>