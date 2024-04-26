<?
include_once("script.php");
$user;
//if(isset($_COOKIE["uid"]))
if(array_key_exists("User",$_GET)){
    $user =  get_user((int)$_GET["User"]); 
}
else $user = false;
//get_user($_COOKIE["uid"]);
?>
<!DOCTYPE html>

<html>
<style>
    p{
        background-color: white;
        color: black;
        border-radius: 10px;
        padding: 2%;
    }
    
    </style>
    <head>
    
    <?
    if(isset($_POST['ava_del'])){
        $user->Avatar = "";
        $connection = connect();
        $path = "./Avatars/".$user->Name."/ava.jpeg";
        if(file_exists($path)){
            unlink($path);
        }
        sqlsrv_query($connection, "UPDATE Users SET Avatar = NULL");
    };
    if(!empty($_FILES["ava"]["tmp_name"])){ 
        $path = "./Avatars/".$user->Name;
        if(!file_exists($path)){
            mkdir($path,0777,true);
        };
        move_uploaded_file($_FILES["ava"]["tmp_name"],$path."/ava.jpeg");
        $user->Avatar = $path."/ava.jpeg";
        //echo($user->Avatar);
        //$str = file_get_contents("./file.jpeg");
        //$str = pack('a', $str);
        //$str = pack("i*",80);
        //$user->Avatar = $str;
        //echo(pack("H*",80)); die;
        //echo($user->Avatar); die; 
        $connection = connect();
        $stmt = sqlsrv_query($connection, "UPDATE Users SET Avatar = '$user->Avatar' WHERE Users.Id = ".$user->Id);
        //var_dump(sqlsrv_errors());
        //unlink("./file.jpeg");
    }
    ?>
    <link href="favicon.png" rel="icon" type="image/png">
    <meta charset="utf-8">
    <title><?$user->Name?></title> 
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="style.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    </head>

    <body class="bg-dark text-light">
        <div class="ms-5 mb-5 me-5 d-flex flex-column text-center align-items-center" style="margin-top:10%;">
        <div><a href="index.php"><img src="logo_white.png"></a></div>
         <?
            if($user){
                if($user->Avatar){
                    //echo("<img id='ava' src = 'data:image/png;base64,".base64_encode($user->Avatar)."'>");
                    echo("
                    <img class='mb-3 ava' style='align-self:center;' src = ".$user->Avatar.">
                    <form method='post'>
                    <button type='submit' class = 'mt-3 mb-3'>Удалить аватар</button>
                    <input type ='hidden' name = 'ava_del' value='del'></input>
                    </form>");
                }
                else {
                    echo("
                <form enctype='multipart/form-data' method='post' class='d-flex flex-column'>
                <div><label for='ava'>Добавить аватар</label>
                <input accept='image/png, image/jpeg' name='ava' type='file'></input></div>
                <button class='m-3 rounded-3' type='submit'>OK</button>
                </form>"
                );
            }
        }
        else die("<h1>Пользователь не задан</h1>");
                    
                ?> 
            <div><p>ПРОФИЛЬ</p>
            <p><?echo($user->Name);?></p>
            <p> 
                <?
                   if(isset($user->Email)) echo($user->Email);
                   else echo("Не задана");
                ?>
                </p>
            <p><a class='text-dark' href="index.php">Вернуться</a></p>
                <form method="GET" class="mb-3" action="favorites.php">
                <button class="p-2 rounded-3">Посмотреть избранные игры</button>
                <input type="hidden" name = 'uid' value = <?echo $user->Id?>></hidden>
            </form>
            
            <button class="rounded-3" onclick="logoff()">Выйти из аккаунта</button>   
        </div>   
    </div>
        <script>
            function logoff(name){
                document.cookie = "uid=''; max-age=-1";
                window.location.replace("index.php");
            }
            </script>
    </body>
</html>