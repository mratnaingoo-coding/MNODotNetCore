const bodyItem = document.querySelector('body')
const toggle = document.getElementById('toggle');
const bulb = document.getElementById('bulb')
toggle.onclick = ()=>{
    toggle.classList.toggle('active')
    bodyItem.classList.toggle('active')

}