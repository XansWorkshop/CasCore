# CasCore: Conservatory Edition

For the original repository, please visit https://github.com/DouglasDwyer/CasCore

## Changes

CasCore: Conservatory Edition implements some special behavior specifically designed for [The Conservatory](https://xansworkshop.com/conservatory). The behavioral changes include the following:

1. Inclusion of `DouglasDwyer.CasCore.ConservatoryInterop.ModMethods` class.
	1. Introduction of `ModMethods.@stackalloc<T>(long count)`. This is a safe shim to the `stackalloc` statement.