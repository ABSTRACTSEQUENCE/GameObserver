<?
use phpailer\phpmailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;
use PHPMailer\PHPMailer\PHPMailer as PHPMailerPHPMailer;

?>
<!DOCTYPE html>
<head>
    <meta charset="utf-8">
    <title>Регистрация/Вход</title> 
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" href="style.css">
    <link href="favicon.ico" rel="icon" >
    </head>
    <style>
        input{
            background: white;
            text-align: center;
        }
        form{
            width: 55%;
            margin-left: 21%;
        }
        #form{
            display: flex;
            flex-direction: column;
            margin-top: 16%;
            border-radius: 18px;
            padding: 89px
        }
        #reg_input{
            position: relative;
            bottom: 13px;
            left: -96px;
            height: 20px;
        }
        #reg_label{
            position: relative;
            bottom: -7px;
        }
        #bt_reg{
            position: relative;
            bottom: -34px;
        }
        #back{
            margin-top: 3%;
        }
    </style>
    <body class="bg-dark text-light text-center m-5 d-flex flex-column align-items-stretch">
    <div style="margin-top:10dp">
    <a href="index.php" class="mb-3">На главную</a>
    <?
            if($_GET["type"] == "reg"){
                echo("<h1>Регистрация</h1>");
            }
            else if($_GET["type"] == "log"){
                echo("<h1>Вход</h1>");
            }
            ?>
        <form method="post">
                <div class = "d-flex flex-column">
                    <label for="nickname">Имя</label>
                    <input name="nickname">
                    <label for="password">Пароль</label>
                    <input type="password" name="password">
                    <label for="email">Почта</label>
                    <input type="email" name="email">
                    <button type="submit" class="mt-3">OK</button>
                </div>
         </form>
    </div>
        <?
       include_once("script.php");
        function reg(){
            if(!isset($_POST["nickname"])|| 
            !isset($_POST["password"]) ||
            !isset($_POST["email"])
            ){
                die("<h1 style = 'color:red'>Все поля должны быть заполнены</h1>");
            };
            //$msg = 
            //"Вы зарегестрировались на сайте *ссылка на сайт*. Вам необходимо перейти по ссылке чтобы подтвердить почту *ссылка*";
            
            
            $all = get_users();
            foreach($all as $user){
                if(
                    $user->Name == $_POST["nickname"] ||
                    $user->Email == $_POST["email"]){
                        die("<h1>Этот пользователь уже зарегестрирован</h1>");
                }
            }
            $user = new User;
            $user->args($_POST["nickname"], $_POST["password"], $_POST["email"]);
            $connection = connect();
            //if($user->Name == "admin") die("<h1>Аккаунт администратора можно создать только через запрос в БД</h1>");
            $query ="INSERT INTO dbo.Users([Name], [Password], Email) VALUES('"
            .$user->Name."','"
            .$user->Password."','"
            .$user->Email."')";
            if(sqlsrv_query($connection, $query)) {
                echo("Пользователь '".$user->Name."' успешно зарегестрирован");
                $_POST["user"] =$user;
            }
            
            else {
                echo("Во время регистрации произошла ошибка");
                $arr = sqlsrv_errors(); 
                foreach( $arr as $i) {echo"<br>"; var_dump($i);};
                die;
            }
        }
        function login(){
            if(!empty($_POST["nickname"]) && !empty($_POST["password"]) && !empty($_POST["email"])) {
                $connection = connect();
                $stmt = sqlsrv_query($connection,"SELECT * FROM Users WHERE Name = '".strval($_POST["nickname"])."' AND Password = '".$_POST["password"]."'");
                if($errors = sqlsrv_errors()) var_dump($errors[0]['message']);
                if(!empty($stmt))
                if(sqlsrv_has_rows($stmt)){
                    $arr = array();
                    $arr = fetch($arr,$stmt,"User");
                    setcookie("uid", $arr[0]->Id);
                    header("location:index.php");
                    die;
                }
                else die("<h2>Неправильно введены данные</h2>");
                else die("<h2>Неправильно введены данные</h2>");
            }
            else die("<h1>Все поля должны быть заполнены</h1>");
            
        }
        if($_GET["type"] == "reg"){
            reg();
        }
        else if($_GET["type"] == "log"){
            login();
        }
        ?>
    </form>
    </body>