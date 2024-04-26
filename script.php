<?

//$users = []; если с юзерами какая-то херь произойдет, раскоменть эту строку


class User{
    public int $Id;
    public $Name;
    public $Password;
    public $Email;
    public $Avatar;
    function args(string $name, string $pass, string $email = null, $Avatar = null){
        $this->Name = $name; $this->Password = $pass; $this->Email = $email; if($Avatar)$this->Avatar = $Avatar;
    }
    public function getName() : string{return $this->Name;}
    public function getPass() : string{return $this->Password;}
    public function getEmail() : string{return $this->Email;}
    public function getId() : int{return $this->Id;}

    public function setId(int $val) {$this->Id = $val;}
    public function setName(string $val) {$this->Name = $val;}
    public function setPass(string $val) {$this->Password = $val;}
    public function setEmail(string $val) {$this->Email = $val;}
}
class Game{
    public int $Id;
    public string $Name;
    public string $Description;
    public string $Genre;
    public string $Steam;
    public $Torrent;
    public $Preview;
    public $Screenshots;
}
class Genre{
    public $Id;
    public $Name;
    //public $Game;
}

function connect(){
    if($connection = sqlsrv_connect("HOME-PC\SQLEXPRESS",array("Database"=>"ObserverDB"))) return $connection;
    else die("ERROR: Connection failed");
}

function get_user($id){
    //if(!isset($_COOKIE["uid"])) return;
    $connection = connect();

    $stmt = sqlsrv_query($connection,"SELECT * FROM dbo.Users WHERE Users.Id = ".$id);
    $user = sqlsrv_fetch_object($stmt,'User');
    
    if(!$user) return null;//die("ERROR: Unable to get user");
    return $user;
}
function get_users(){
    $connection = connect();
    $stmt = sqlsrv_query($connection, "SELECT * FROM dbo.Users");
    $arr = array();
    $arr = fetch($arr,$stmt,"User");
    return $arr;
}

function get_comments(){
    $connection = connect();
    $cmd = "SELECT Comments.Id AS CommentId, Users.Name AS 'Username', Comments.Text AS 'Text', Games.Id AS 'GameId' FROM Users, dbo.Comments, dbo.Games WHERE Comments.User_Id = Users.Id AND Comments.Game_Id = Games.Id";
    //"SELECT Comments.Id AS 'CommentId', Users.Name AS 'Username', Games.Name AS 'Game', Text AS 'Text' FROM Comments, Users, Games WHERE User_Id = Users.Id AND Comments.Game_Id = Games.Id AND dbo.Games.Id = ".$gameId .";";
    if(!$stmt = sqlsrv_query($connection, 
    $cmd)){
        var_dump(sqlsrv_errors());
    };
    $arr = array();
    while ($i = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)){
        array_push($arr, $i);
    };
    if(!$arr) {
        return false;
    }
    return $arr;
}
function get_screenshots(int $gameId){
    $connection = connect();
    $stmt = sqlsrv_query($connection, "SELECT Image FROM dbo.Screenshots WHERE Game_Id =".$gameId);
    $arr = array();
    while($i = sqlsrv_fetch_array($stmt)){
        array_push($arr, $i[0]);
    };
    if(!$arr) return false;
    else return $arr;
}
function error(string $text){
    echo("ERROR: ".$text);
}
function get_games(){
    $games = [];
    $connection = connect();
    $stmt = sqlsrv_query($connection, "SELECT * FROM dbo.Games");
    $games = fetch($games,$stmt,"Game");
    foreach($games as $game){
        $game->Preview = base64_encode($game->Preview);
    }
    return $games;
}
function get_game($id){
    $game = null;
    $all = get_games();
    foreach($all as $g){
        if($g->Id == $id) $game = $g;
    }
    if($game != null){
        return $game;
    }
    else return false;
}
function fetch(array $arr, $stmt, string $class_name){
    while($i = sqlsrv_fetch_object($stmt,$class_name)){
        //var_dump($i); echo "<br>";
        array_push($arr, $i);
    }
    return $arr;
}
$connection = connect();
//echo("Connected to ".sqlsrv_server_info($connection)["SQLServerName"]."<br>");

//$games = fetch($games,"SELECT * FROM dbo.Games","Game");
//$users = fetch($users,"SELECT * FROM dbo.Users","User");
//$stmt = sqlsrv_query($connection, "SELECT Genres.[Name] AS 'Name', Games.[Name] AS 'Game' FROM dbo.Genres, dbo.Games");

$users = sqlsrv_fetch_object(sqlsrv_query($connection,"SELECT * FROM dbo.Users"),"User");
//$genres = sqlsrv_fetch_object(sqlsrv_query($connection, "SELECT Genres.[Name] AS 'Name', Games.[Name] AS 'Game' FROM dbo.Genres, dbo.Games"),"Genre");
function get_genres(){
    $genres = [];
    $connection = connect();
    $stmt = sqlsrv_query($connection, "SELECT * FROM dbo.Genres");
    $genres = fetch($genres,$stmt,"Genre");
    return $genres;
}

function get_genre(int $id){
    $all = get_genres();
    foreach($all as $genre){
        if($genre->Id == $id) return $genre;
    }
    return null;
}

function genreOf(int $gameId, int $genreId){
    $connection = connect();
    $stmt = sqlsrv_query($connection, "SELECT Game_Id, Genre_Id FROM dbo.GenreGames WHERE Game_Id = ".$gameId." AND Genre_Id = ".$genreId);
    $arr = array();
    
    while($i = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)){
        array_push($arr, $i);
    };
    //if(count($arr)<=0) {echo("No matches found for ".get_game($gameId)->Name." and ".get_genre($genreId)->Name);}
    foreach($arr as $game_genre){
        if($game_genre["Game_Id"] == $gameId && $game_genre["Genre_Id"] == $genreId){
            //echo(get_game($gameId)->Name." has the ".get_genre($genreId)->Name." genre");
            return true;
            //if($game["Genre_Id"] == $genreId) {echo(get_game($game["Game_Id"])->Name.":".get_genre($genreId)->Name); return true;}
        }
    }
    return false;
    //var_export($arr);
}



?>