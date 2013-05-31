﻿namespace x360NANDManager.SPI {
    internal sealed class PICFlash : ARMBase {
        internal PICFlash() {
            Initialized = DeviceInit(0xffff, 0x4);
        }

        public bool FlashErase(uint block, bool verboseError = false) {
            if(base.FlashErase(block)) {
                GetFlashStatus();
                Utils.IsBadBlock(Status, block, "Erasing", verboseError);
                return true;
            }
            return false;
        }

        public bool FlashWrite(uint block, byte[] buf, bool verboseError = false) {
            if(base.FlashWrite(block, buf)) {
                GetFlashStatus();
                Utils.IsBadBlock(Status, block, "Writing", verboseError);
                return true;
            }
            return false;
        }
    }
}