// wwwroot/js/deck-calculator.js
import init, { DeckManager } from '../wasm/deck_calculator.js';

let wasmInitialized = false;

export async function createDeckManager(tier) {
    if (!wasmInitialized) {
        await init();
        wasmInitialized = true;
        console.log('WASM Modul initialisiert');
    }
    
    return new DeckManager(tier);
}