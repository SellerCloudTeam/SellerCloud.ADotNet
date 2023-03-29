// ---------------------------------------------------------------------------
// Copyright (c) Hassan Habib & Shri Humrudha Jagathisun All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace ADotNet
{
    // for more take a look at this blog:
    // https://blog.hompus.nl/2020/08/17/yaml-properties-as-scalar-or-sequence-or-both/

    /// <summary>
    /// Sequence converter which converts all types representing sequence to <see cref="SequenceStyle.Flow"/>
    /// </summary>
    public class SequenceConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
            => typeof(IEnumerable<string>).IsAssignableFrom(type);

        /// <summary>
        /// Deserialization
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ReadYaml(IParser parser, Type type)
        {
            // for deserialization
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serialization
        /// </summary>
        /// <param name="emitter"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            var sequence = (IEnumerable<string>)value;
            emitter.Emit(new SequenceStart(default, default, false, SequenceStyle.Flow));

            foreach (var item in sequence)
            {
                emitter.Emit(new Scalar(default, item));
            }

            emitter.Emit(new SequenceEnd());
        }
    }
}
