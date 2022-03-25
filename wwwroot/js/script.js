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

function validaAdocao()
{
    var invalid = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/; //expressao regular 
    var nome = document.getElementById('txtnome');
    var email = document.getElementById('txtemail');
    var telefone = document.getElementById('txttelefone');
    var datanascimento = document.getElementById('txtdatanascimento');
    var endereco = document.getElementById('txtendereco');
    var cidade = document.getElementById('txtcidade');
    var estado = document.getElementById('txtestado');
    var cep = document.getElementById('txtcep');
    var animal = document.getElementById('txtanimal');

    caixa_nome = document.querySelector('.msg-nome');
    caixa_nome.style.display = 'none';

    caixa_email = document.querySelector('.msg-email');
    caixa_email.style.display = 'none';

    caixa_telefone = document.querySelector('.msg-telefone');
    caixa_telefone.style.display = 'none';

    caixa_datanascimento = document.querySelector('.msg-datanascimento');
    caixa_datanascimento.style.display = 'none';

    caixa_endereco = document.querySelector('.msg-endereco');
    caixa_endereco.style.display = 'none';

    caixa_cidade = document.querySelector('.msg-cidade');
    caixa_cidade.style.display = 'none';

    caixa_estado = document.querySelector('.msg-estado');
    caixa_estado.style.display = 'none';

    caixa_cep = document.querySelector('.msg-cep');
    caixa_cep.style.display = 'none';

    caixa_animal = document.querySelector('.msg-animal');
    caixa_animal.style.display = 'none';

    if (nome.value.length < 5)
    {
        caixa_nome.innerHTML = "Favor preencha o campo!";
        caixa_nome.style.display = 'block';
        nome.focus();
        return false;
    }

    if (email.value=="")
    {
        caixa_email.innerHTML = "Favor preencha o campo!";
        caixa_email.style.display = 'block';
        email.focus();
        return false;
    }

    if (invalid.test(email.value)==false)
    {
        caixa_email.innerHTML = "Endereço de e-mail inválido!";
        caixa_email.style.display = 'block';
        email.focus();
        return false;
    }

    if (telefone.value.length < 5)
    {
        caixa_telefone.innerHTML = "Favor preencha o campo!";
        caixa_telefone.style.display = 'block';
        telefone.focus();
        return false;
    }

    if (datanascimento.value.length < 5)
    {
        caixa_datanascimento.innerHTML = "Favor preencha o campo!";
        caixa_datanascimento.style.display = 'block';
        datanascimento.focus();
        return false;
    }

    if (endereco.value.length < 5)
    {
        caixa_endereco.innerHTML = "Favor preencha o campo!";
        caixa_endereco.style.display = 'block';
        endereco.focus();
        return false;
    }

    if (cidade.value.length < 5)
    {
        caixa_cidade.innerHTML = "Favor preencha o campo!";
        caixa_cidade.style.display = 'block';
        cidade.focus();
        return false;
    }

    if (estado.value.length < 5)
    {
        caixa_estado.innerHTML = "Favor preencha o campo!";
        caixa_estado.style.display = 'block';
        estado.focus();
        return false;
    }

    if (cep.value.length < 5)
    {
        caixa_cep.innerHTML = "Favor preencha o campo!";
        caixa_cep.style.display = 'block';
        cep.focus();
        return false;
    }

    if (animal.value.length < 5)
    {
        caixa_animal.innerHTML = "Favor preencha o campo!";
        caixa_animal.style.display = 'block';
        animal.focus();
        return false;
    }
}

function validaFale()
{
    var invalid = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/; //expressao regular 
    var nome = document.getElementById('txtnome');
    var email = document.getElementById('txtemail');
    var mensagem = document.getElementById('txtmensagem');
    
    caixa_nome = document.querySelector('.msg-nome');
    caixa_nome.style.display = 'none';

    caixa_email = document.querySelector('.msg-email');
    caixa_email.style.display = 'none';

    caixa_mensagem = document.querySelector('.msg-mensagem');
    caixa_mensagem.style.display = 'none';
 
    if (nome.value.length < 5)
    {
        caixa_nome.innerHTML = "Favor preencha o campo!";
        caixa_nome.style.display = 'block';
        nome.focus();
        return false;
    }

    if (email.value=="")
    {
        caixa_email.innerHTML = "Favor preencha o campo!";
        caixa_email.style.display = 'block';
        email.focus();
        return false;
    }

    if (invalid.test(email.value)==false)
    {
        caixa_email.innerHTML = "Endereço de e-mail inválido!";
        caixa_email.style.display = 'block';
        email.focus();
        return false;
    }

    if (mensagem.value.length < 5)
    {
        caixa_mensagem.innerHTML = "Favor preencha o campo!";
        caixa_mensagem.style.display = 'block';
        mensagem.focus();
        return false;
    }
}

function validaVoluntario()
{
    var invalid = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/; //expressao regular 
    var nome = document.getElementById('txtnome');
    var email = document.getElementById('txtemail');
    var telefone = document.getElementById('txttelefone');
    var datanascimento = document.getElementById('txtdatanascimento');
    var sexo = document.getElementById('txtsexo');

    caixa_nome = document.querySelector('.msg-nome');
    caixa_nome.style.display = 'none';

    caixa_email = document.querySelector('.msg-email');
    caixa_email.style.display = 'none';

    caixa_telefone = document.querySelector('.msg-telefone');
    caixa_telefone.style.display = 'none';

    caixa_datanascimento = document.querySelector('.msg-datanascimento');
    caixa_datanascimento.style.display = 'none';

    caixa_sexo = document.querySelector('.msg-sexo');
    caixa_sexo.style.display = 'none';

    if (nome.value.length < 5)
    {
        caixa_nome.innerHTML = "Favor preencha o campo!";
        caixa_nome.style.display = 'block';
        nome.focus();
        return false;
    }

    if (email.value=="")
    {
        caixa_email.innerHTML = "Favor preencha o campo!";
        caixa_email.style.display = 'block';
        email.focus();
        return false;
    }

    if (invalid.test(email.value)==false)
    {
        caixa_email.innerHTML = "Endereço de e-mail inválido!";
        caixa_email.style.display = 'block';
        email.focus();
        return false;
    }

    if (telefone.value.length < 5)
    {
        caixa_telefone.innerHTML = "Favor preencha o campo!";
        caixa_telefone.style.display = 'block';
        telefone.focus();
        return false;
    }

    if (datanascimento.value.length < 5)
    {
        caixa_datanascimento.innerHTML = "Favor preencha o campo!";
        caixa_datanascimento.style.display = 'block';
        datanascimento.focus();
        return false;
    }

    if (sexo.value.length < 5)
    {
        caixa_sexo.innerHTML = "Favor preencha o campo!";
        caixa_sexo.style.display = 'block';
        sexo.focus();
        return false;
    }
}