﻿using System;

namespace AngouriMath;
    
partial record Entity
{
    partial record Number
    {
        partial record Complex :
            IClosedArithmetics<Complex>,
            IDivisionOperators<Complex, Complex, Complex>,
            IHasAbsoluteValue<Complex, Real>,
            IHasNeutralValues<Complex>
        {
            /// <inheritdoc/>
            public static new Complex AdditiveIdentity { get; } = 0;

            /// <inheritdoc/>
            public static new Complex MultiplicativeIdentity { get; } = 1;
        }

        partial record Real :
            IScalarClosedArithmetics<Real>,
            IDivisionOperators<Real, Real, Real>,
            IHasAbsoluteValue<Real, Real>,
            IHasNeutralValues<Real>
        {
            /// <inheritdoc/>
            public static new Real AdditiveIdentity { get; } = 0;

            /// <inheritdoc/>
            public static new Real MultiplicativeIdentity { get; } = 1;

            /// <inheritdoc/>
            public int CompareTo(object? obj) => this.CompareTo(obj as Real);

            /// <inheritdoc/>
            public static Real Abs(Real self) => self.Abs();
        }

        partial record Rational :
            IScalarClosedArithmetics<Rational>,
            IDivisionOperators<Rational, Rational, Real>,
            IHasAbsoluteValue<Rational, Rational>,
            IHasNeutralValues<Rational>
        {
            /// <inheritdoc/>
            public static Rational Abs(Rational self) => self.Abs().Downcast<Rational>();

            /// <inheritdoc/>
            public static new Rational AdditiveIdentity { get; } = 0;

            /// <inheritdoc/>
            public static new Rational MultiplicativeIdentity { get; } = 1;
        }
    }
}

