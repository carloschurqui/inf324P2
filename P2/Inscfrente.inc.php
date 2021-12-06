<!DOCTYPE html>
<html lang="en">
<head>
    <title>Document</title>
    <style>
        form{
            position: relative;
            width: 500px;
            height: 600px;
            padding-left: 20px;
            padding-top: 15px;
            background-color: #6CF5E8;
            border-radius: 20px;
            margin:auto;
        }
        
        input[type=text]{
            width: 470px;
            height: 35px;
            font: 14px normal normal uppercase helvetica, arial, serif;
        }
        input[type=submit]{
            position: relative;
            width: 150px;
            height: 40px;
            border-radius: 20px;
            margin-left: 150px;
            border:0px;
            background-color: #0C25C4;
            font: 14px normal normal uppercase helvetica, arial, serif;

        }

        p{
            text-shadow: 0 1px 0 #fff;
            font-size: 24px;
        }

        label{
            margin: 11px 20px 0 0;
            font-size: 16px;
            color: #000;
            text-transform: uppercase;
            text-shadow: 0px 1px 0px #fff;
        }
    </style>
</head>
<body>
    <div class="from">
        <form action="Inscfrente.cab.inc.php" method="$_POST">
        <input type="hidden" value="<?php echo $fila['formulario'];?>" name="formulario"/>
		<input type="hidden" value="<?php echo $flujo?>" name="flujo"/>
		<input type="hidden" value="<?php echo $proceso?>" name="proceso"/>
        <p>SIGLA</p>
        <label for="nombre">SIGLA DEL FRENTE</label>
        <input type="text" name="sigla" placeholder="SIGLA" required>
        <br>
        <p>REPRESENTANTE</p>
        <label for="correo">REPRESENTANTE</label>
        <input type="text" name="repre" placeholder="REPRESENTANTE" required>
        <br>
        <br>
        <input type="submit" value="Inscribir">
        </form>
    </div>
</body>
</html>