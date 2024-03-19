
const btnModal = document.getElementById("btnModal");
const btnClose = document.getElementById("btnClose");
const overlay = document.querySelector(".overlay");
const modal = document.querySelector(".modal");

let w = window.innerWidth;
let h = window.innerHeight;

const openModal = () => {

    w = window.innerWidth;
    h = window.innerHeight;
    
    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");

    modal.style.transform = `translate(${(w - 500) / 2}px, ${(h - 200) / 2}px`;
}

const closeModal = () => {
    modal.classList.add("hidden");
    overlay.classList.add("hidden");
}

btnModal.addEventListener("click", openModal);
btnClose.addEventListener("click", closeModal);



let isDragging = false;
let startX, startY, modalX, modalY;

modal.addEventListener("mousedown", mouseDown);
modal.addEventListener("mousemove", mouseMove);
modal.addEventListener("mouseup", mouseUp);

function mouseDown(e) {

    isDragging = true;
    modal.style.cursor = "move";
    
    w = window.innerWidth;
    h = window.innerHeight;

    startX = e.clientX;
    startY = e.clientY;

    let positionInfo = modal.getBoundingClientRect();
    let modalTop = positionInfo.top;
    let modalLeft = positionInfo.left;

    modalX = modalLeft || 0;
    modalY = modalTop || 0;
}

function mouseMove(e){

    if (!isDragging) return;

    let x = e.clientX;
    let y = e.clientY;
    
    let newX = modalX + x - startX;
    let newY = modalY + y - startY;

    if (newX >= 0 && newX <= (w - 500) && newY >= 0 && newY <= (h - 200)){   
        this.style.transform = `translate(${newX}px, ${newY}px)`
    }
}
    
function mouseUp(){

    isDragging = false;
    modal.style.cursor = "unset";
}