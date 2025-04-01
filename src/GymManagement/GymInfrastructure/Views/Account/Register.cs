
@model GymManagementMVC.ViewModel.RegisterViewModel

@{
    ViewData["Title"] = "Реєстрація";
}

< h2 > @ViewData["Title"] </ h2 >

< form asp - action = "Register" method = "post" >
    < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >


    < div class= "form-group" >
        < label asp -for= "Email" ></ label >
        < input asp -for= "Email" class= "form-control" />
        < span asp - validation -for= "Email" class= "text-danger" ></ span >
    </ div >


    < div class= "form-group" >
        < label asp -for= "Year" ></ label >
        < input asp -for= "Year" class= "form-control" />
        < span asp - validation -for= "Year" class= "text-danger" ></ span >
    </ div >


    < div class= "form-group" >
        < label asp -for= "Password" ></ label >
        < input asp -for= "Password" type = "password" class= "form-control" />
        < span asp - validation -for= "Password" class= "text-danger" ></ span >
    </ div >


    < div class= "form-group" >
        < label asp -for= "PasswordConfirm" ></ label >
        < input asp -for= "PasswordConfirm" type = "password" class= "form-control" />
        < span asp - validation -for= "PasswordConfirm" class= "text-danger" ></ span >
    </ div >


    < button type = "submit" class= "btn btn-primary" > Зареєструватися </ button >
</ form >

