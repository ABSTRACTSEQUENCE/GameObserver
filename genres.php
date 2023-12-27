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
    <body class="bg-dark text-light" background="Pictures\Background\bg.jpg">
        <div class="container">
            <div class="row">
                <style>
                    .genreList{
                        display: flex;
                        flex-direction: column;
                        background-color: #212529;
                    }
                </style>
                <div class = 'col genreList'>
                    <?
                    include("script.php");
                    $genres = get_genres();
                    foreach($genres as $genre){
                        echo("<div class='col' ><a href='index.php?genre=".$genre->Id."'>".$genre->Name."</a></div>");
                    }
                    ?>
                    </div>
            </div>
        </div>
    </body>
</html>