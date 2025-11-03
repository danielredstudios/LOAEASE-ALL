<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Live Queue Display - LOA-EASE</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;600;700;800&display=swap" rel="stylesheet">
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        
        body { 
            font-family: 'Poppins', sans-serif; 
            background: linear-gradient(135deg, #001a33 0%, #003366 50%, #004080 100%);
            color: white; 
            overflow: hidden;
            position: relative;
            min-height: 100vh;
        }
        
        /* Animated background pattern */
        body::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-image: 
                radial-gradient(circle at 20% 50%, rgba(0, 85, 164, 0.1) 0%, transparent 50%),
                radial-gradient(circle at 80% 80%, rgba(255, 199, 44, 0.05) 0%, transparent 50%);
            animation: pulse 15s ease-in-out infinite;
            pointer-events: none;
        }
        
        @keyframes pulse {
            0%, 100% { opacity: 1; }
            50% { opacity: 0.6; }
        }
        
        .main-container { 
            display: grid; 
            grid-template-columns: 2fr 1fr; 
            height: 100vh; 
            gap: clamp(0.75rem, 2vw, 2rem); 
            padding: clamp(0.75rem, 2vw, 2rem);
            position: relative;
            z-index: 1;
        }
        
        .serving-section, .waiting-section { 
            background: rgba(0, 42, 82, 0.85);
            backdrop-filter: blur(10px);
            border-radius: clamp(1rem, 2vw, 2rem); 
            padding: clamp(1rem, 2.5vw, 2.5rem); 
            display: flex; 
            flex-direction: column;
            box-shadow: 0 20px 60px rgba(0, 0, 0, 0.3);
            border: 1px solid rgba(255, 255, 255, 0.1);
            overflow: hidden;
        }
        
        .section-header {
            text-align: center;
            margin-bottom: clamp(1rem, 2vw, 2rem);
            position: relative;
            flex-shrink: 0;
        }
        
        .section-header h1 {
            font-size: clamp(1.5rem, 4vw, 3.5rem); 
            font-weight: 800;
            background: linear-gradient(135deg, #FFC72C 0%, #FFD700 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
            text-shadow: 0 4px 20px rgba(255, 199, 44, 0.3);
            letter-spacing: clamp(1px, 0.2vw, 2px);
            line-height: 1.2;
        }
        
        .section-header::after {
            content: '';
            display: block;
            width: clamp(50px, 10vw, 100px);
            height: clamp(2px, 0.4vw, 4px);
            background: linear-gradient(90deg, transparent, #FFC72C, transparent);
            margin: clamp(0.5rem, 1vw, 1rem) auto 0;
            border-radius: 2px;
        }
        
        .serving-grid { 
            display: grid; 
            grid-template-columns: repeat(2, 1fr); 
            grid-template-rows: repeat(2, 1fr); 
            gap: clamp(0.75rem, 1.5vw, 1.5rem); 
            flex-grow: 1;
            min-height: 0;
        }
        
        .counter-card { 
            background: linear-gradient(135deg, #FFFFFF 0%, #F8F9FA 100%);
            color: #003366; 
            border-radius: clamp(0.75rem, 1.5vw, 1.5rem); 
            text-align: center; 
            padding: clamp(0.75rem, 2vw, 2rem) clamp(0.5rem, 1vw, 1rem); 
            border: clamp(2px, 0.3vw, 3px) solid #0055a4;
            transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
            display: flex; 
            flex-direction: column; 
            justify-content: center;
            position: relative;
            overflow: hidden;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
            min-height: 0;
        }
        
        .counter-card::before {
            content: '';
            position: absolute;
            top: 0;
            left: -100%;
            width: 100%;
            height: 100%;
            background: linear-gradient(90deg, transparent, rgba(255, 199, 44, 0.1), transparent);
            transition: left 0.5s;
        }
        
        .counter-card:hover::before {
            left: 100%;
        }
        
        .counter-card.greyout { 
            background: linear-gradient(135deg, #e9ecef 0%, #dee2e6 100%);
            opacity: 0.5;
            border-color: #adb5bd;
        }
        
        .counter-card.highlight { 
            transform: scale(1.03); 
            box-shadow: 0 0 60px rgba(255, 199, 44, 0.8), 0 20px 40px rgba(0, 0, 0, 0.3);
            border-color: #FFC72C;
            animation: glow 0.5s ease-in-out;
        }
        
        @keyframes glow {
            0%, 100% { box-shadow: 0 0 60px rgba(255, 199, 44, 0.8); }
            50% { box-shadow: 0 0 80px rgba(255, 199, 44, 1); }
        }
        
        .counter-card .counter-name { 
            font-size: clamp(1rem, 2.5vw, 2.5rem); 
            font-weight: 700;
            margin-bottom: clamp(0.25rem, 0.5vw, 0.5rem);
            color: #0055a4;
            line-height: 1.2;
        }
        
        .counter-card .serving-number { 
            font-size: clamp(2.5rem, 8vw, 8rem); 
            font-weight: 800; 
            line-height: 1;
            background: linear-gradient(135deg, #003366 0%, #0055a4 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
        }
        
        .counter-card.greyout .serving-number,
        .counter-card.greyout .counter-name {
            background: #6c757d;
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
        }
        
        .branding-header { 
            border-bottom: clamp(2px, 0.3vw, 3px) solid rgba(255, 199, 44, 0.3);
            padding-bottom: clamp(0.75rem, 1.5vw, 1.5rem); 
            margin-bottom: clamp(1rem, 2vw, 2rem);
            text-align: center;
            flex-shrink: 0;
        }
        
        .branding-header .brand-title { 
            font-size: clamp(1.5rem, 3.5vw, 3rem); 
            font-weight: 800; 
            background: linear-gradient(135deg, #FFC72C 0%, #FFD700 100%);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
            margin: 0 0 clamp(0.25rem, 0.5vw, 0.5rem) 0;
            letter-spacing: clamp(1px, 0.3vw, 3px);
            line-height: 1.2;
        }
        
        .branding-header .brand-subtitle { 
            font-size: clamp(0.75rem, 1.5vw, 1.5rem); 
            opacity: 0.9;
            margin: 0;
            font-weight: 400;
            color: #b8d4f1;
            line-height: 1.3;
        }
        
        .queue-header {
            font-size: clamp(1.25rem, 2.5vw, 2.5rem);
            font-weight: 800;
            text-align: center;
            margin-bottom: clamp(0.75rem, 1.5vw, 1.5rem);
            color: #FFC72C;
            letter-spacing: clamp(0.5px, 0.1vw, 1px);
            flex-shrink: 0;
            line-height: 1.2;
        }
        
        .waiting-list { 
            list-style: none; 
            padding: 0; 
            flex-grow: 1; 
            overflow-y: auto;
            scrollbar-width: thin;
            scrollbar-color: #FFC72C rgba(255, 255, 255, 0.1);
            min-height: 0;
        }
        
        .waiting-list::-webkit-scrollbar {
            width: clamp(6px, 0.8vw, 8px);
        }
        
        .waiting-list::-webkit-scrollbar-track {
            background: rgba(255, 255, 255, 0.05);
            border-radius: 10px;
        }
        
        .waiting-list::-webkit-scrollbar-thumb {
            background: #FFC72C;
            border-radius: 10px;
        }
        
        .waiting-list-item { 
            background: linear-gradient(135deg, rgba(0, 64, 128, 0.8) 0%, rgba(0, 85, 164, 0.8) 100%);
            padding: clamp(0.75rem, 1.5vw, 1.25rem); 
            border-radius: clamp(0.5rem, 1vw, 1rem); 
            margin-bottom: clamp(0.5rem, 1vw, 1rem); 
            font-size: clamp(1rem, 2.2vw, 2.2rem); 
            font-weight: 700; 
            text-align: center;
            border: clamp(1px, 0.2vw, 2px) solid rgba(255, 199, 44, 0.2);
            transition: all 0.3s ease;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
            line-height: 1.3;
        }
        
        .waiting-list-item:hover {
            transform: translateX(5px);
            border-color: rgba(255, 199, 44, 0.5);
            box-shadow: 0 6px 20px rgba(0, 0, 0, 0.3);
        }
        
        .waiting-list-item.opacity-50 {
            opacity: 0.5;
        }
        
        /* Status badges */
        .status-badge {
            display: inline-block;
            padding: clamp(0.25rem, 0.5vw, 0.5rem) clamp(0.5rem, 1vw, 1rem);
            border-radius: 2rem;
            font-size: clamp(0.75rem, 1.5vw, 1.5rem);
            font-weight: 600;
            margin-top: clamp(0.25rem, 0.5vw, 0.5rem);
            line-height: 1.2;
        }
        
        .status-offline {
            background: linear-gradient(135deg, #dc3545, #c82333);
            color: white;
        }
        
        .status-break {
            background: linear-gradient(135deg, #ffc107, #ff9800);
            color: #000;
        }
        
        /* Tablet landscape - adjust layout */
        @media (max-width: 1400px) {
            .main-container {
                gap: 1.5rem;
                padding: 1.5rem;
            }
        }
        
        /* Tablet portrait */
        @media (max-width: 1024px) {
            .main-container {
                grid-template-columns: 1fr;
                grid-template-rows: 1.5fr 1fr;
                gap: 1rem;
                padding: 1rem;
            }
            
            .section-header h1 {
                font-size: clamp(1.5rem, 5vw, 2.5rem);
            }
            
            .serving-grid {
                gap: 1rem;
            }
        }
        
        /* Mobile landscape */
        @media (max-width: 768px) and (orientation: landscape) {
            .main-container {
                grid-template-columns: 1.5fr 1fr;
                grid-template-rows: 1fr;
            }
            
            .serving-grid {
                grid-template-columns: repeat(2, 1fr);
                grid-template-rows: repeat(2, 1fr);
            }
        }
        
        /* Mobile portrait */
        @media (max-width: 768px) {
            body {
                overflow-y: auto;
                overflow-x: hidden;
            }
            
            .main-container {
                grid-template-columns: 1fr;
                grid-template-rows: auto auto;
                height: auto;
                min-height: 100vh;
                gap: 1rem;
                padding: 1rem;
            }
            
            .serving-section, .waiting-section {
                padding: 1.5rem 1rem;
            }
            
            .section-header {
                margin-bottom: 1rem;
            }
            
            .section-header h1 {
                font-size: clamp(1.5rem, 6vw, 2rem);
            }
            
            .serving-grid {
                grid-template-columns: repeat(2, 1fr);
                grid-template-rows: auto;
                gap: 0.75rem;
                min-height: auto;
            }
            
            .counter-card {
                padding: 1rem 0.5rem;
                min-height: 120px;
            }
            
            .counter-card .counter-name {
                font-size: clamp(0.875rem, 3.5vw, 1.25rem);
            }
            
            .counter-card .serving-number {
                font-size: clamp(2rem, 10vw, 4rem);
            }
            
            .status-badge {
                font-size: clamp(0.65rem, 2.5vw, 0.875rem);
                padding: 0.25rem 0.5rem;
            }
            
            .branding-header .brand-title {
                font-size: clamp(1.5rem, 5vw, 2rem);
            }
            
            .branding-header .brand-subtitle {
                font-size: clamp(0.75rem, 3vw, 1rem);
            }
            
            .queue-header {
                font-size: clamp(1.25rem, 4vw, 1.75rem);
            }
            
            .waiting-list {
                max-height: 50vh;
            }
            
            .waiting-list-item {
                font-size: clamp(1rem, 4vw, 1.5rem);
                padding: 1rem 0.75rem;
            }
        }
        
        /* Extra small devices */
        @media (max-width: 480px) {
            .main-container {
                padding: 0.75rem;
                gap: 0.75rem;
            }
            
            .serving-section, .waiting-section {
                padding: 1rem 0.75rem;
                border-radius: 1rem;
            }
            
            .serving-grid {
                grid-template-columns: 1fr;
                grid-template-rows: repeat(4, 1fr);
                gap: 0.75rem;
            }
            
            .counter-card {
                min-height: 100px;
            }
            
            .counter-card .serving-number {
                font-size: clamp(2rem, 12vw, 3rem);
            }
            
            .waiting-list-item:hover {
                transform: translateX(3px);
            }
        }
        
        /* Very small devices */
        @media (max-width: 360px) {
            .section-header h1 {
                font-size: 1.5rem;
            }
            
            .counter-card .counter-name {
                font-size: 0.875rem;
            }
            
            .counter-card .serving-number {
                font-size: 2rem;
            }
            
            .waiting-list-item {
                font-size: 1rem;
            }
        }
    </style>
</head>
<body>
    <div class="main-container">
        <div class="serving-section">
            <div class="section-header">
                <h1>NOW SERVING</h1>
            </div>
            <div id="serving-grid" class="serving-grid"></div>
        </div>
        <div class="waiting-section">
            <div class="branding-header">
                <p class="brand-title">LOA-EASE</p>
                <p class="brand-subtitle">Lyceum of Alabang Queuing System</p>
            </div>
            <h2 class="queue-header">IN QUEUE</h2>
            <ul id="waiting-list" class="waiting-list"></ul>
        </div>
    </div>
    <audio id="notification-sound" preload="auto">
        <source src="https://assets.mixkit.co/active_storage/sfx/2869/2869-preview.mp3" type="audio/mpeg">
    </audio>
    <audio id="ding-sound" preload="auto">
        <source src="https://assets.mixkit.co/active_storage/sfx/2013/2013-preview.mp3" type="audio/mpeg">
    </audio>
    
    <!-- Click anywhere to enable sound overlay -->
    <div id="sound-enable-overlay" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; background: rgba(0, 51, 102, 0.95); z-index: 9999; display: flex; align-items: center; justify-content: center; cursor: pointer;">
        <div style="text-align: center; color: white; padding: 2rem;">
            <h2 style="font-size: 2rem; margin-bottom: 1rem;">🔊 Enable Sound</h2>
            <p style="font-size: 1.5rem;">Click anywhere to activate audio notifications</p>
        </div>
    </div>
    
    <script>
        const servingGrid = document.getElementById('serving-grid');
        const waitingList = document.getElementById('waiting-list');
        const notificationSound = document.getElementById('notification-sound');
        const dingSound = document.getElementById('ding-sound');
        const soundOverlay = document.getElementById('sound-enable-overlay');
        let currentServingState = {};
        let soundEnabled = false;
        
        // Enable sound on first user interaction
        soundOverlay.addEventListener('click', () => {
            soundEnabled = true;
            soundOverlay.style.display = 'none';
            
            // Test play sounds to initialize
            notificationSound.volume = 0.7;
            dingSound.volume = 0.8;
            dingSound.play().then(() => dingSound.pause()).catch(e => console.log('Sound init:', e));
            notificationSound.play().then(() => notificationSound.pause()).catch(e => console.log('Sound init:', e));
        });
        
        // Text-to-speech function
        function speakNumber(counterName, number) {
            if ('speechSynthesis' in window && soundEnabled) {
                window.speechSynthesis.cancel();
                
                const utterance = new SpeechSynthesisUtterance();
                utterance.text = `Now serving number ${number} at ${counterName}`;
                utterance.lang = 'en-US';
                utterance.rate = 0.9;
                utterance.pitch = 1.0;
                utterance.volume = 1.0;
                
                setTimeout(() => {
                    window.speechSynthesis.speak(utterance);
                }, 800);
            }
        }

        function updateDisplay() {
            fetch('api/get_live_status.php')
                .then(response => response.json())
                .then(data => {
                    if (!data.counters) return;

                    servingGrid.innerHTML = '';
                    let soundPlayed = false;

                    data.counters.forEach(counter => {
                        const servingNumber = counter.serving_number || '---';
                        const card = document.createElement('div');
                        card.className = 'counter-card';
                        
                        if (counter.is_open == '0' || counter.status === 'break') {
                            card.classList.add('greyout');
                        }

                        let statusText = servingNumber;
                        let statusBadge = '';
                        
                        if (counter.is_open == '0') {
                            statusText = '---';
                            statusBadge = '<span class="status-badge status-offline">OFFLINE</span>';
                        } else if (counter.status === 'break') {
                            statusText = '---';
                            statusBadge = '<span class="status-badge status-break">ON BREAK</span>';
                        }
                        
                        card.innerHTML = `
                            <div class="counter-name">${counter.counter_name}</div>
                            <div class="serving-number">${statusText}</div>
                            ${statusBadge}
                        `;
                        servingGrid.appendChild(card);

                        if (currentServingState[counter.counter_id] && currentServingState[counter.counter_id] !== servingNumber && servingNumber !== '---' && !soundPlayed) {
                            soundPlayed = true;
                            card.classList.add('highlight');
                            setTimeout(() => card.classList.remove('highlight'), 2000);
                        }
                        currentServingState[counter.counter_id] = servingNumber;
                    });

                    waitingList.innerHTML = '';
                    if (data.waiting_list && data.waiting_list.length > 0) {
                        data.waiting_list.forEach(item => {
                            const li = document.createElement('li');
                            li.className = 'waiting-list-item';
                            li.textContent = item;
                            waitingList.appendChild(li);
                        });
                    } else {
                        const li = document.createElement('li');
                        li.className = 'waiting-list-item opacity-50';
                        li.textContent = 'No Students Waiting';
                        waitingList.appendChild(li);
                    }
                })
                .catch(error => console.error('Error fetching live status:', error));
        }

        document.addEventListener('DOMContentLoaded', () => {
            updateDisplay();
            setInterval(updateDisplay, 3000);
        });
    </script>
</body>
</html>