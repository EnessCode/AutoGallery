(function () {
    const form = document.getElementById('carForm');
    const tabBtns = [...document.querySelectorAll('.ftab')];

    function activeIndex() { return tabBtns.findIndex(b => b.classList.contains('active')); }
    function go(i) {
        if (i < 0 || i >= tabBtns.length) return;
        bootstrap.Tab.getOrCreateInstance(tabBtns[i]).show();
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }
    document.getElementById('btnPrev').addEventListener('click', () => go(activeIndex() - 1));
    document.getElementById('btnNext').addEventListener('click', () => go(activeIndex() + 1));
    tabBtns.forEach((b, i) => b.addEventListener('shown.bs.tab', () => {
        document.getElementById('btnPrev').style.visibility = i === 0 ? 'hidden' : 'visible';
        document.getElementById('btnNext').style.display = i === tabBtns.length - 1 ? 'none' : 'block';
    }));
    document.getElementById('btnPrev').style.visibility = 'hidden';

    function markTabErrors() {
        tabBtns.forEach(b => {
            const pane = document.querySelector(b.dataset.bsTarget);
            const bad = pane.querySelector(':invalid, .input-validation-error');
            b.classList.toggle('has-error', !!bad);
        });
    }
    form.addEventListener('input', markTabErrors);
    markTabErrors();

    form.addEventListener('submit', function (e) {
        const bad = form.querySelector(':invalid');
        if (bad) {
            e.preventDefault();
            markTabErrors();
            const pane = bad.closest('.tab-pane');
            const btn = tabBtns.find(b => b.dataset.bsTarget === '#' + pane.id);
            bootstrap.Tab.getOrCreateInstance(btn).show();
            setTimeout(() => bad.reportValidity(), 200);
        }
    });

    const order = ['Orijinal', 'Boyalı', 'Değişen'];
    const keyOf = { 'Orijinal': 'ok', 'Boyalı': 'paint', 'Değişen': 'chg' };
    const selects = [...document.querySelectorAll('.xp-select')];

    function paint(sel) {
        const k = keyOf[sel.value] || 'ok';
        document.querySelectorAll('.xp[data-part="' + sel.dataset.part + '"]').forEach(el => el.dataset.status = k);
        sel.closest('.xp-row').dataset.status = k;
    }
    function summary() {
        const c = { ok: 0, paint: 0, chg: 0 };
        selects.forEach(s => c[keyOf[s.value] || 'ok']++);
        document.getElementById('cntOk').textContent = c.ok;
        document.getElementById('cntPaint').textContent = c.paint;
        document.getElementById('cntChg').textContent = c.chg;
    }
    selects.forEach(s => {
        paint(s);
        s.addEventListener('change', () => { paint(s); summary(); });
    });
    document.querySelectorAll('.xp').forEach(el => {
        el.addEventListener('click', () => {
            const s = document.getElementById('Expertise_' + el.dataset.part);
            s.value = order[(order.indexOf(s.value) + 1) % order.length];
            s.dispatchEvent(new Event('change'));
        });
    });
    document.querySelectorAll('.xp-row').forEach(row => {
        const shapes = () => document.querySelectorAll('.xp[data-part="' + row.dataset.part + '"]');
        row.addEventListener('mouseenter', () => shapes().forEach(s => s.classList.add('hl')));
        row.addEventListener('mouseleave', () => shapes().forEach(s => s.classList.remove('hl')));
    });
    document.getElementById('btnResetXp').addEventListener('click', () => {
        selects.forEach(s => { s.value = 'Orijinal'; paint(s); });
        summary();
    });
    summary();

    document.querySelectorAll('.feat-group').forEach(g => {
        const boxes = [...g.querySelectorAll('input[type=checkbox]')];
        const count = g.querySelector('.feat-count');
        const toggle = g.querySelector('.feat-toggle');
        function refresh() {
            const n = boxes.filter(b => b.checked).length;
            count.textContent = n;
            toggle.textContent = n === boxes.length ? 'Seçimi Kaldır' : 'Tümünü Seç';
        }
        boxes.forEach(b => b.addEventListener('change', refresh));
        toggle.addEventListener('click', () => {
            const all = boxes.every(b => b.checked);
            boxes.forEach(b => b.checked = !all);
            refresh();
        });
        refresh();
    });

    const input = document.getElementById('UploadedImages');
    const grid = document.getElementById('thumbGrid');
    const zone = document.getElementById('dropzone');
    const mainField = document.getElementById('MainImageIndex');
    const MAX_FILES = 20, MAX_SIZE = 8 * 1024 * 1024;
    let files = [];
    let main = parseInt(mainField.value || '0', 10) || 0;

    function sync() {
        const dt = new DataTransfer();
        files.forEach(f => dt.items.add(f));
        input.files = dt.files;
        mainField.value = main;
    }
    function render() {
        grid.innerHTML = '';
        files.forEach((f, i) => {
            const t = document.createElement('div');
            t.className = 'thumb position-relative rounded overflow-hidden shadow-sm' + (i === main ? ' is-main border border-warning border-3' : ' border');
            t.style.width = '120px'; t.style.height = '120px';

            const img = document.createElement('img');
            img.src = URL.createObjectURL(f);
            img.alt = f.name;
            img.style.width = '100%'; img.style.height = '100%'; img.style.objectFit = 'cover';
            t.appendChild(img);

            t.insertAdjacentHTML('beforeend',
                (i === main ? '<span class="badge bg-warning position-absolute top-0 start-0 m-1">Ana Foto</span>' : '') +
                '<div class="t-tools position-absolute bottom-0 w-100 d-flex justify-content-center bg-dark bg-opacity-75 p-1 gap-2">' +
                '<button type="button" class="btn btn-sm text-white p-0" data-a="main" title="Ana fotoğraf yap"><i class="bi ' + (i === main ? 'bi-star-fill text-warning' : 'bi-star') + '"></i></button>' +
                '<button type="button" class="btn btn-sm text-danger p-0" data-a="del" title="Kaldır"><i class="bi bi-trash"></i></button>' +
                '</div>');

            t.querySelector('[data-a=main]').onclick = () => { main = i; sync(); render(); };
            t.querySelector('[data-a=del]').onclick = () => {
                files.splice(i, 1);
                if (main === i) main = 0; else if (main > i) main--;
                sync(); render();
            };
            grid.appendChild(t);
        });
    }
    function add(list) {
        for (const f of list) {
            if (!/^image\/(jpeg|png|webp)$/.test(f.type)) continue;
            if (f.size > MAX_SIZE) { alert(f.name + ' 8 MB sınırını aşıyor.'); continue; }
            if (files.length >= MAX_FILES) { alert('En fazla ' + MAX_FILES + ' fotoğraf yükleyebilirsiniz.'); break; }
            files.push(f);
        }
        sync(); render();
    }
    input.addEventListener('change', () => add([...input.files].filter(f => !files.includes(f))));
    ['dragenter', 'dragover'].forEach(ev => zone.addEventListener(ev, e => { e.preventDefault(); zone.classList.add('border-primary', 'bg-primary-subtle'); }));
    ['dragleave', 'drop'].forEach(ev => zone.addEventListener(ev, e => { e.preventDefault(); zone.classList.remove('border-primary', 'bg-primary-subtle'); }));
    zone.addEventListener('drop', e => add([...e.dataTransfer.files]));
})();