/* =========================================================
   ŞİŞÇİ ATEŞ — main.js
   Has Burdur Şiş · Kepez / Antalya
   ========================================================= */

/* ---------------------------------------------------------
   MENÜ — Burdur mutfağı. Fiyat gösterilmez.
   Açıklamaları dilediğiniz gibi düzenleyebilirsiniz.
   --------------------------------------------------------- */
const MENU = [
  {
    cat: '🔥 Şişler & Kebaplar',
    items: [
      { name: 'Meşhur Burdur Şiş', desc: 'Dana kaburganın en makbul yerinden, katkısız; odun ateşinde ağır ağır pişen, dışı çıtır içi yumuşacık tescilli lezzet.' },
      { name: 'Kuşbaşı Şiş', desc: 'İri kuşbaşı dana etleri, közün üstünde mühürlenir; her lokmada etin saf tadı.' },
      { name: 'Tavuk Şiş', desc: 'Özel marine edilmiş, sulu ve yumuşacık tavuk parçaları; ateşte hafif is kokusuyla.' },
      { name: 'Tavuk Kanat', desc: 'Kıpkırmızı köz üstünde çıtırlaşan, baharatlı ve doyurucu kanatlar.' },
      { name: 'Ciğer Şiş', desc: 'Taze dana ciğeri, tam kıvamında; közde nefis bir kahvaltı ve akşam keyfi.' },
      { name: 'Adana Kebabı', desc: 'Zırhla çekilmiş, ateşin harıyla dengelenen o meşhur baharatlı lezzet.' },
      { name: 'Patlıcan Kebabı', desc: 'Közlenmiş patlıcanla et arasında dizilen, dumanlı ve iştah açıcı klasik.' },
      { name: 'Köfte', desc: 'El yoğurması, mis gibi baharatlı köftelerimiz; ateşin üstünde cızır cızır.' },
      { name: 'Kiremitte Köfte', desc: 'Sıcacık kiremit tabakta, sos ve sebzeleriyle fokurdayarak gelen köfte ziyafeti.' },
      { name: 'Kiremitte Kaşarlı Kuşbaşılı', desc: 'Kuşbaşı et, erimiş bol kaşar ve sebzelerle kiremitte buluşan doyumsuz lezzet.' },
    ],
  },
  {
    cat: '🥖 Odun Fırını Pideleri',
    items: [
      { name: 'Kıymalı Pide', desc: 'Baharatlı taze kıyma, ince açılmış hamurda; odun fırınında altın rengine gelene dek.' },
      { name: 'Kuşbaşılı Pide', desc: 'İri kuşbaşı parçalarıyla bereketli, doyurucu ve mis kokulu.' },
      { name: 'Kaşarlı Pide', desc: 'Uzayan bol kaşar; çıtır hamurla mükemmel uyum.' },
      { name: 'Peynirli Pide', desc: 'Bol peynirli, hafif ve nefis; her yaşa hitap eden klasik.' },
      { name: 'Kıymalı Kaşarlı Pide', desc: 'Kıymanın baharatı, kaşarın kıvamıyla birleşen tam lezzet.' },
    ],
  },
  {
    cat: '🍲 Çorbalar',
    items: [
      { name: 'Mercimek Çorbası', desc: 'Kadifemsi kıvamda, sıcacık; limon ve pul biberle tam kıvamında.' },
      { name: 'Kelle Paça', desc: 'Saatlerce kaynayan geleneksel, besleyici ve şifa niyetine.' },
      { name: 'Tavuk Suyu Çorba', desc: 'Hafif, doyurucu ve iç ısıtan; naçizane bir klasik.' },
    ],
  },
  {
    cat: '🥗 Salata & Meze',
    items: [
      { name: 'Tahinli Piyaz', desc: 'Antalya usulü tahinli piyaz; şişin yanında olmazsa olmaz eşlikçi.' },
      { name: 'Mevsim Salata', desc: 'Günlük taze mevsim yeşillikleri; ferahlatan bir tabak.' },
      { name: 'Ezme & Közleme', desc: 'Közlenmiş biber-domates ve acılı ezme; sofranın renkli tamamlayıcısı.' },
    ],
  },
  {
    cat: '🍰 Tatlılar',
    items: [
      { name: 'Kadayıf Tatlısı', desc: 'Kıtır kıtır tel kadayıf, şerbetiyle; yemeğin sonuna tatlı bir nokta.' },
      { name: 'Tahinli Kabak Tatlısı', desc: 'Cevizli, tahinli klasik kabak tatlısı; ağızda dağılan geleneksel lezzet.' },
    ],
  },
  {
    cat: '🥤 İçecekler',
    items: [
      { name: 'Ayran', desc: 'Bol köpüklü, taze; şişin en iyi arkadaşı.' },
      { name: 'Şalgam', desc: 'Acılı ya da acısız; kebabın yanında ferahlatan seçim.' },
      { name: 'Su & Maden Suyu', desc: 'Erikli su ve maden suyu çeşitleri.' },
      { name: 'Meşrubatlar', desc: 'Kola, Fanta, Sprite ve soğuk gazlı içecek çeşitleri.' },
    ],
  },
];

/* ---------------------------------------------------------
   GALERİ — Instagram fotoğraflarınızı buraya ekleyin.
   img: '' boşsa yer tutucu görünür. Fotoğrafı gorseller/
   klasörüne koyup yolunu yazın: img: 'gorseller/1.jpg'
   --------------------------------------------------------- */
const GALLERY = [
  { img: '', alt: 'Meşhur Burdur Şiş' },
  { img: '', alt: 'Tavuk Şiş' },
  { img: '', alt: 'Adana Kebabı' },
  { img: '', alt: 'Kuşbaşı Şiş' },
  { img: '', alt: 'Kıymalı Pide' },
  { img: '', alt: 'Kiremitte Köfte' },
  { img: '', alt: 'Ciğer Şiş' },
  { img: '', alt: 'Mekandan kareler' },
];

document.addEventListener('DOMContentLoaded', () => {

  /* --- Yıl --- */
  const yearEl = document.getElementById('year');
  if (yearEl) yearEl.textContent = new Date().getFullYear();

  /* --- Navbar scroll --- */
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

  /* --- Menüyü oluştur --- */
  const menuCols = document.getElementById('menuCols');
  if (menuCols) {
    MENU.forEach(group => {
      const card = document.createElement('div');
      card.className = 'menu-card';
      const items = group.items.map(it => `
        <li>
          <span class="mi-name">${it.name}</span>
          <span class="mi-desc">${it.desc}</span>
        </li>`).join('');
      card.innerHTML = `<h3 class="menu-cat">${group.cat}</h3><ul class="menu-items">${items}</ul>`;
      menuCols.appendChild(card);
    });
  }

  /* --- Galeriyi oluştur --- */
  const grid = document.getElementById('galleryGrid');
  if (grid) {
    GALLERY.forEach((p, i) => {
      const item = document.createElement('div');
      item.className = 'gallery-item';
      item.style.transitionDelay = `${(i % 4) * 0.08}s`;
      item.innerHTML = p.img
        ? `<img src="${p.img}" alt="${p.alt}" loading="lazy">`
        : `<span>📷</span><small>${p.alt}</small>`;
      grid.appendChild(item);
    });
  }

  /* --- Scroll reveal --- */
  const revealEls = document.querySelectorAll(
    '.about-text, .about-media, .menu-card, .section-head, .contact-info, .contact-map, .gallery-item, .q-card'
  );
  revealEls.forEach(el => el.classList.add('reveal'));

  if ('IntersectionObserver' in window) {
    const io = new IntersectionObserver((entries) => {
      entries.forEach(e => {
        if (e.isIntersecting) { e.target.classList.add('visible'); io.unobserve(e.target); }
      });
    }, { threshold: 0.12 });
    revealEls.forEach(el => io.observe(el));
  } else {
    revealEls.forEach(el => el.classList.add('visible'));
  }
});
