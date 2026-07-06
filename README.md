# 🔥 Şişçi Ateş — Has Burdur Şiş | Web Sitesi

Antalya Kepez'de, **Antalya Şehir Hastanesi'ne yakın** konumdaki [@sisciates](https://www.instagram.com/sisciates) işletmesi için modern, tek sayfa (one-page) restoran web sitesi. Odun ateşi temalı, tamamen mobil uyumlu ve yerel SEO'ya (Antalya / Kepez / Şehir Hastanesi) göre optimize edilmiştir.

## 📁 Dosya Yapısı

```
.
├── index.html          # Ana sayfa (tüm bölümler + SEO + harita)
├── css/styles.css      # Tasarım / stil
├── js/main.js          # Menü, galeri, animasyonlar
└── gorseller/          # Fotoğraflarınızı buraya koyun
```

## ✅ Sitede Hazır Olanlar

- **Gerçek menü** (fiyatsız, iştah açıcı açıklamalarla) — Burdur şiş, kebaplar, odun fırını pideleri, çorbalar, tatlılar, içecekler
- **İletişim:** Çankaya Mah. Barış Manço Bulvarı No:277, Kepez / Antalya — Tel & WhatsApp **0555 556 15 07**
- **Google Haritalar** konumu gömülü
- **SEO:** Antalya / Kepez / Şehir Hastanesi anahtar kelimeleri + Google için yapısal veri (JSON-LD)
- **Kalite & Hijyen** bölümü (temizlik, taze et, doğru pişirme, müşteri memnuniyeti)

## 📷 Fotoğraf Ekleme (tek eksik adım)

Instagram, fotoğrafların otomatik indirilmesini engellediği için görselleri koda gömemedim. Eklemek çok kolay:

1. Instagram/flyer fotoğraflarını `gorseller/` klasörüne kopyalayın (`1.jpg`, `burdur-sis.jpg` ...).
2. `js/main.js` içindeki `GALLERY` listesinde `img: ''` kısmını doldurun:
   ```js
   { img: 'gorseller/burdur-sis.jpg', alt: 'Meşhur Burdur Şiş' },
   ```
3. Hakkımızda bölümündeki büyük fotoğraf için `index.html` içinde `about-photo` alanına
   `<img src="gorseller/ekip.jpg" alt="Şişçi Ateş ekibi">` ekleyin.

## 🚀 Yayınlama

`index.html` dosyasını çift tıklayarak tarayıcıda açabilirsiniz. Yayına almak için tüm klasörü bir hosting'e (Netlify, GitHub Pages, cPanel) yükleyin.

### GitHub Pages
Repo → **Settings → Pages** → Branch seçin → **Save**.

---
Has Burdur Şiş — Odun ateşinde gerçek lezzet. 🔥 · Kepez / Antalya
