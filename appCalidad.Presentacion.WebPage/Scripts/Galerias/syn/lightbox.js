function openLightbox() {
	document.querySelector(".overlay").classList.add("active");
	document.querySelector(".lightbox").classList.add("active");
}

function closeLightbox() {
	document.querySelector(".overlay").classList.remove("active");
	document.querySelector(".lightbox").classList.remove("active");
}

function openLightboxPEKA() {
	document.querySelector(".overlay").classList.add("active");
	document.querySelector(".lightboxPEKA").classList.add("active");
}

function closeLightboxPEKA() {
	document.querySelector(".overlay").classList.remove("active");
	document.querySelector(".lightboxPEKA").classList.remove("active");
}
// Cerrar con tecla ESC
//document.addEventListener("keydown", function (e) {
//	if (e.key === "Escape") {
//		closeLightbox();
//	}
//});
