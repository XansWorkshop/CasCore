# CasCore: Conservatory Edition

For the original repository, please visit https://github.com/DouglasDwyer/CasCore

## Changes

CasCore: Conservatory Edition implements some special behavior specifically designed for [The Conservatory](https://xansworkshop.com/conservatory). The behavioral changes include the following:

1. Introduce a special shim to allow `Span<T> span = stackalloc T[n]` pattern by injecting verification code.
2. Add support for .NET 10 SIMD code.