
const btnModal = document.getElementById("btnModal");
const btnClose = document.getElementById("btnClose");
const modal = document.querySelector(".modal");
const overlay = document.querySelector(".overlay");

const openModal = () => {
    modal.classList.remove("hidden");
    overlay.classList.remove("hidden");
}

const closeModal = () => {
    modal.classList.add("hidden");
    overlay.classList.add("hidden");
}

btnModal.addEventListener("click", openModal);
btnClose.addEventListener("click", closeModal);
