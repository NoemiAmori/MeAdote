var slideIndex = 1;
var slideIndex2 = 0;

showSlidesAutomatic ();

function plusSlides (n)
{
    showSlides (slideIndex += n)
}

function currentSlide (n)
{
    showSlides(slideIndex = n)
}

function showSlides (n)
{
    var i;
    var slides = document.getElementsByClassName("meusSlides");
    var dots = document.getElementsByClassName ("dot");

    if (n > slides.length)
    {
        slideIndex = 1
    }

    if (n < 1)
    {
        slideIndex = slides.length
    }

    for (i = 0; i < slides.length; i++)
    {
        slides[i].style.display = "none";
    }

    for (i = 0; i < dots.length; i++)
    {
        dots[i].className = dots[i].className.replace(" active", "")
    }

    slides [slideIndex -1].style.display = "block";
    dots [slideIndex -1].className += " active";

}

function showSlidesAutomatic ()
{
    var i;
    var slides = document.getElementsByClassName("meusSlides");
    var dots = document.getElementsByClassName ("dot");

    for (i = 0; i < slides.length; i++)
    {
        slides[i].style.display = "none";
    }

    slideIndex2++;

    if (slideIndex2 > slides.length)
    {
        slideIndex2 = 1
    }

    for (i = 0; i < dots.length; i++)
    {
        dots[i].className = dots[i].className.replace(" active", "")
    }

    slides[slideIndex2 -1].style.display = "block";
    dots[slideIndex2 -1].className += " active";

    setTimeout (showSlidesAutomatic, 3000);
}

function Cadastrar()
{

    let parametros =
    {
        Nome: $("#nome").val(),
        Email: $("#email").val(),
        Mensagem: $("#mensagem").val()
    }

    $.post('/Fale/Cadastro', parametros)

   .done(
     function(data){
         if(data.status=="Cadastro realizado com sucesso!!!"){
             $("#frmFale").after("<h3>Dados cadastrados com sucesso</h3>");
             $("#frmFale").hide();
             
         }
         else{
            $("#frmFale").after("<h3>"+data.mensagem+"</h3>");
         }
     }
   )

   .fail(
       function(){
           alert("Ocorreu um erro de Conexão!!!")
       }
   );

}

$(document).ready(

    function ()
    {
        $("#frmFale").submit(
            function(e)
            {
                e.preventDefault();
                Cadastrar();
            }
        );    
    }
);

function Cadastrar()
{

    let parametros =
    {
        Nome: $("#nome").val(),
        Email: $("#email").val(),
        Telefone: $("#telefone").val(),
        DataNascimento: $("#datanascimento").val(),
        Endereco: $("#endereco").val(),
        Cidade: $("#cidade").val(),
        Estado: $("#estado").val,
        Cep: $("#cep").val,
        Animal: $("#animal")
    }

    $.post('/Adocao/Cadastro', parametros)
    
   .done(
     function(data){
         if(data.status=="Cadastro realizado com sucesso!!!"){
             $("#frmAdocao").after("<h3>Dados cadastrados com sucesso</h3>");
             $("#frmAdocao").hide();
             
         }
         else{
            $("#frmAdocao").after("<h3>"+data.mensagem+"</h3>");
         }
     }
   )

   .fail(
       function(){
           alert("Ocorreu um erro de Conexão!!!")
       }
   );

}

$(document).ready(

    function ()
    {
        $("#frmAdocao").submit(
            function(e)
            {
                e.preventDefault();
                Cadastrar();
            }
        );    
    }
);

function Cadastrar()
{

    let parametros =
    {
        Nome: $("#nome").val(),
        Email: $("#email").val(),
        Telefone: $("#telefone").val()
    }

    $.post('/Voluntario/Cadastro', parametros)
    
   .done(
     function(data){
         if(data.status=="Cadastro realizado com sucesso!!!"){
             $("#frmVoluntario").after("<h3>Dados cadastrados com sucesso</h3>");
             $("#frmVoluntario").hide();
             
         }
         else{
            $("#frmVoluntario").after("<h3>"+data.mensagem+"</h3>");
         }
     }
   )

   .fail(
       function(){
           alert("Ocorreu um erro de Conexão!!!")
       }
   );

}

$(document).ready(

    function ()
    {
        $("#frmVoluntario").submit(
            function(e)
            {
                e.preventDefault();
                Cadastrar();
            }
        );    
    }
);