namespace PKHeXRNG
{
    /// <summary>
    /// SIMD-oriented Fast Mersenne Twister
    /// </summary>
    /// <remarks>
    /// Adapted from:
    /// https://github.com/wwwwwwzx/3DSRNGTool/blob/255a32956a6491f99b579dd98c627eb699bc889a/3DSRNGTool/RNG/SFMT.cs
    /// via
    /// http://rei.to/random.html
    /// </remarks>
    public class SFMT
    {
        #region Fields

        public const int MEXP = 19937;
        public const int POS1 = 122;
        public const int SL1 = 18;
        public const int SR1 = 11;
        public const uint MSK1 = 0xdfffffefU;
        public const uint MSK2 = 0xddfecb7fU;
        public const uint MSK3 = 0xbffaffffU;
        public const uint MSK4 = 0xbffffff6U;
        public readonly uint[] PARITY = { 1u, 0u, 0u, 0x13c9e684u };

        public const int N = (MEXP / 128) + 1;
        public const int N32 = 4 * N;

        /// <summary>
        /// Internal state vector.
        /// </summary>
        public readonly uint[] state = new uint[N32];

        /// <summary>
        /// The index to be used as the next random number among the internal state vectors.
        /// </summary>
        public int Index;

        #endregion

        /// <summary>
        /// Initialize the pseudorandom number generator with a period of (2 ^ 19937 - 1) with <see cref="seed"/> as the seed.
        /// </summary>
        public SFMT(uint seed)
        {
            Initialize(seed);
        }

        public SFMT(SFMT old)
        {
            Index = old.Index;
            old.state.CopyTo(state, 0);
        }

        /// <summary>
        /// Get the next unsigned 32 bit pseudorandom number.
        /// </summary>
        private uint Next32()
        {
            if (Index >= N32)
            {
                GeneratePeriod();
                Index = 0;
            }
            return state[Index++];
        }

        /// <summary>
        /// Initialize the generator.
        /// </summary>
        /// <param name="seed"></param>
        public void Initialize(uint seed)
        {
            // Internal state array initialization
            state[0] = seed;
            for (var i = 1; i < N32; i++)
                state[i] = (uint)((0x6C078965 * (state[i - 1] ^ (state[i - 1] >> 30))) + i);

            // Confirmation
            CertifyPeriod();

            // Initial position setting
            Index = N32;
        }

        /// <summary>
        /// Check that the internal state vector is appropriate and adjust as necessary.
        /// </summary>
        public void CertifyPeriod()
        {
            uint inner = 0;

            for (var i = 0; i < 4; i++)
                inner ^= state[i] & PARITY[i];
            for (var i = 16; i > 0; i >>= 1)
                inner ^= inner >> i;
            inner &= 1;

            // check OK
            if (inner == 1)
                return;

            // check NG, and modification
            for (var i = 0; i < 4; i++)
            {
                uint work = 1;
                int j;
                for (j = 0; j < 32; j++)
                {
                    if ((work & PARITY[i]) != 0)
                    {
                        state[i] ^= work;
                        return;
                    }
                    work <<= 1;
                }
            }
        }

        /// <summary>
        /// For gen_rand_all (2 ^ 19937-1) period.
        /// </summary>
        private void GeneratePeriod()
        {
            var p = state;

            var a = 0;
            var b = POS1 * 4;
            var c = (N - 2) * 4;
            var d = (N - 1) * 4;
            do
            {
                p[a + 3] = p[a + 3] ^ (p[a + 3] << 8) ^ (p[a + 2] >> 24) ^ (p[c + 3] >> 8) ^ ((p[b + 3] >> SR1) & MSK4) ^ (p[d + 3] << SL1);
                p[a + 2] = p[a + 2] ^ (p[a + 2] << 8) ^ (p[a + 1] >> 24) ^ (p[c + 3] << 24) ^ (p[c + 2] >> 8) ^ ((p[b + 2] >> SR1) & MSK3) ^ (p[d + 2] << SL1);
                p[a + 1] = p[a + 1] ^ (p[a + 1] << 8) ^ (p[a + 0] >> 24) ^ (p[c + 2] << 24) ^ (p[c + 1] >> 8) ^ ((p[b + 1] >> SR1) & MSK2) ^ (p[d + 1] << SL1);
                p[a + 0] = p[a + 0] ^ (p[a + 0] << 8) ^ (p[c + 1] << 24) ^ (p[c + 0] >> 8) ^ ((p[b + 0] >> SR1) & MSK1) ^ (p[d + 0] << SL1);
                c = d; d = a; a += 4; b += 4;
                if (b >= N32) b = 0;
            } while (a < N32);
        }

        public void Reseed(uint seed)
        {
            Initialize(seed);
        }

        public ulong Next64()
        {
            lock (_lock)
            {
                return Next32() | ((ulong) Next32() << 32);
            }
        }

        public object _lock = new object();

        public void Next()
        {
            lock (_lock)
            {
                Next32();
                Next32();
            }
        }
    }
}