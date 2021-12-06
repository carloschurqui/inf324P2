<?php
    include "conexion.inc.php";

    
    $sigla = $_POST["sigla"];
    $repre = $_POST["repre"];

    $sql = "INSERT INTO FRENTES VALUES('$sigla', '$repre')";

    $ejecutar = mysqli_query($conn, $sql);
    if(!$ejecutar){
        echo "Hubo un error";
    }
    else{
        echo "Guardado correctamente";
    }
    
?>