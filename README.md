# 🔥 Şişçi Ateş — Web Sitesi

[@sisciates](https://www.instagram.com/sisciates) için hazırlanmış modern, tek sayfa (one-page) restoran web sitesi. Odun ateşi / köz temalı, tamamen mobil uyumlu.

## 📁 Dosya Yapısı

```
.
├── index.html          # Ana sayfa (tüm bölümler)
├── css/styles.css      # Tasarım / stil
├── js/main.js          # Menü, galeri, animasyonlar
└── gorseller/          # Fotoğraflarınızı buraya koyun
```

## 🚀 Nasıl Çalıştırılır?

`index.html` dosyasına çift tıklayın — tarayıcıda açılır. Sunucuya yüklemek için tüm klasörü hosting'e (Netlify, GitHub Pages, cPanel vb.) atmanız yeterli.

### GitHub Pages ile yayınlama
1. Repo → **Settings → Pages**
2. Branch: `main` (veya bu branch) → **Save**
3. Birkaç dakika sonra `https://<kullanıcı>.github.io/<repo>` adresinde yayında.

## 📷 Instagram Fotoğraflarını Ekleme

> **Not:** Instagram, fotoğrafların otomatik indirilmesini engellediği için görselleri koda gömemedim. Fotoğrafları kendiniz ekleyeceksiniz — çok kolay:

1. Instagram'daki fotoğrafları kaydedin.
2. `gorseller/` klasörüne kopyalayın (`1.jpg`, `2.jpg` ...).
3. `js/main.js` içindeki `galleryPhotos` listesinde `img: ''` kısmını doldurun:
   ```js
   { img: 'gorseller/1.jpg', alt: 'Adana şiş' },
   ```

## ✏️ Güncellenmesi Gerekenler

Sitede yer tutucu (placeholder) olarak bırakılan alanlar:

- **Menü fiyatları** — `index.html` içinde `₺---` yazan yerler
- **Telefon numarası** — `tel:+900000000000` ve `wa.me/900000000000`
- **Adres & çalışma saatleri** — İletişim bölümü
- **Google Haritalar** — İletişim bölümündeki harita alanı

Bu bilgileri bana iletirseniz sizin için otomatik doldurabilirim.

---
Odun ateşinde pişen gerçek lezzet. 🔥
