const form = document.getElementById('btu-form');
const resultSection = document.getElementById('result');
const btuOutput = document.getElementById('btu-output');
const kwOutput = document.getElementById('kw-output');
const recommendation = document.getElementById('recommendation');
const breakdown = document.getElementById('breakdown');

const multipliers = {
  climate: {
    cool: 0.95,
    mild: 1,
    hot: 1.15,
  },
  orientation: {
    low: 0.95,
    normal: 1,
    high: 1.12,
  },
  insulation: {
    good: 0.92,
    average: 1,
    poor: 1.15,
  },
  roomType: {
    bedroom: 0.95,
    living: 1,
    kitchen: 1.1,
    office: 1.05,
  },
  appliances: {
    low: 1,
    medium: 1.05,
    high: 1.12,
  },
};

function suggestStandardBtu(rawBtu) {
  const standards = [9000, 12000, 18000, 24000, 30000, 36000, 48000];
  return standards.find((value) => rawBtu <= value) ?? standards[standards.length - 1];
}

form.addEventListener('submit', (event) => {
  event.preventDefault();

  const area = Number(document.getElementById('area').value);
  const height = Number(document.getElementById('height').value);
  const climate = document.getElementById('climate').value;
  const orientation = document.getElementById('orientation').value;
  const insulation = document.getElementById('insulation').value;
  const roomType = document.getElementById('roomType').value;
  const people = Number(document.getElementById('people').value);
  const appliances = document.getElementById('appliances').value;

  const baseBtu = area * 400;
  const volumeFactor = height / 2.7;
  const peopleExtra = Math.max(0, people - 1) * 600;

  const totalBtu =
    (baseBtu + peopleExtra) *
    volumeFactor *
    multipliers.climate[climate] *
    multipliers.orientation[orientation] *
    multipliers.insulation[insulation] *
    multipliers.roomType[roomType] *
    multipliers.appliances[appliances];

  const rounded = Math.round(totalBtu / 100) * 100;
  const standard = suggestStandardBtu(rounded);
  const kw = (rounded / 3412).toFixed(2);

  btuOutput.textContent = `Tahmini ihtiyaç: ${rounded.toLocaleString('tr-TR')} BTU/h`;
  kwOutput.textContent = `Yaklaşık soğutma kapasitesi: ${kw} kW`;
  recommendation.textContent = `Önerilen standart klima kapasitesi: ${standard.toLocaleString('tr-TR')} BTU/h`;

  const rows = [
    `Temel hesap (alan × 400): ${Math.round(baseBtu).toLocaleString('tr-TR')} BTU/h`,
    `Tavan yüksekliği katsayısı: ${volumeFactor.toFixed(2)}`,
    `Kişi etkisi: +${Math.round(peopleExtra).toLocaleString('tr-TR')} BTU/h`,
    `İklim katsayısı: ${multipliers.climate[climate]}`,
    `Cephe katsayısı: ${multipliers.orientation[orientation]}`,
    `Yalıtım katsayısı: ${multipliers.insulation[insulation]}`,
    `Oda tipi katsayısı: ${multipliers.roomType[roomType]}`,
    `Cihaz katsayısı: ${multipliers.appliances[appliances]}`,
  ];

  breakdown.innerHTML = rows.map((item) => `<li>${item}</li>`).join('');
  resultSection.classList.remove('hidden');
});
