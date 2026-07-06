/* =========================================================
   ŞİŞÇİ ATEŞ — main.js
   ========================================================= */

document.addEventListener('DOMContentLoaded', () => {

  /* --- Yıl (footer) --- */
  const yearEl = document.getElementById('year');
  if (yearEl) yearEl.textContent = new Date().getFullYear();

  /* --- Navbar: kaydırınca koyulaşsın --- */
  const navbar = document.getElementById('navbar');
  const onScroll = () => navbar.classList.toggle('scrolled', window.scrollY > 40);
  onScroll();
  window.addEventListener('scroll', onScroll, { passive: true });

  /* --- Mobil menü --- */
  const navToggle = document.getElementById('navToggle');
  const navLinks  = document.getElementById('navLinks');
  navToggle.addEventListener('click', () => {
    navToggle.classList.toggle('open');
    navLinks.classList.toggle('open');
  });
  navLinks.querySelectorAll('a').forEach(a =>
    a.addEventListener('click', () => {
      navToggle.classList.remove('open');
      navLinks.classList.remove('open');
    })
  );

  /* --- Galeri alanlarını oluştur ---
     Instagram fotoğraflarınızı buraya ekleyin:
     Aşağıdaki dizideki her { img: 'gorseller/1.jpg' } satırını
     kendi görselinizin yoluyla değiştirin. img boşsa yer tutucu görünür. */
  const galleryPhotos = [
    { img: '', alt: 'Adana şiş' },
    { img: '', alt: 'Tavuk şiş' },
    { img: '', alt: 'Mangal ateşi' },
    { img: '', alt: 'Karışık ızgara' },
    { img: '', alt: 'Dürüm' },
    { img: '', alt: 'Köfte' },
    { img: '', alt: 'Salata & meze' },
    { img: '', alt: 'Ambiyans' },
  ];

  const grid = document.getElementById('galleryGrid');
  if (grid) {
    galleryPhotos.forEach((p, i) => {
      const item = document.createElement('div');
      item.className = 'gallery-item reveal';
      item.style.transitionDelay = `${(i % 4) * 0.08}s`;
      if (p.img) {
        item.innerHTML = `<img src="${p.img}" alt="${p.alt}" loading="lazy">`;
      } else {
        item.innerHTML = `<span>📷</span><small>${p.alt}</small>`;
      }
      grid.appendChild(item);
    });
  }

  /* --- Scroll reveal animasyonu --- */
  const revealEls = document.querySelectorAll(
    '.about-text, .about-media, .menu-card, .section-head, .contact-info, .contact-map, .gallery-item'
  );
  revealEls.forEach(el => el.classList.add('reveal'));

  if ('IntersectionObserver' in window) {
    const io = new IntersectionObserver((entries) => {
      entries.forEach(e => {
        if (e.isIntersecting) {
          e.target.classList.add('visible');
          io.unobserve(e.target);
        }
      });
    }, { threshold: 0.12 });
    revealEls.forEach(el => io.observe(el));
  } else {
    revealEls.forEach(el => el.classList.add('visible'));
  }
});
