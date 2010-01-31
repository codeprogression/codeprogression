/*************************************************************************
 *  Flash Card Master
 *  Copyleft (C) 2006 Nithin Philips
 *
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU General Public License
 *  as published by the Free Software Foundation; either version 2
 *  of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation,Inc.,59 Temple Place - Suite 330,Boston,MA 02111-1307, USA.
 *
 *  Author            :  Nithin Philips <spikiermonkey@users.sourceforge.net>
 *  Original FileName :  DictionarySerializer.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System;

public class DictionarySerializer<K, V>
{
    public struct SerializableKeyValuePair<TKey, TValue>
    {
	   public TKey Key;
	   public TValue Value;
	   public SerializableKeyValuePair(KeyValuePair<TKey, TValue> kvp) {
		  this.Key = kvp.Key;
		  this.Value = kvp.Value;
	   }
    }

    private XmlSerializer Serializer = new XmlSerializer(typeof(List<SerializableKeyValuePair<K, V>>));

    public void Serialize(Dictionary<K, V> dictionary, XmlWriter serializationStream) {
	   Serializer.Serialize(serializationStream, BuildItemList(dictionary));
    }
    public void Serialize(Dictionary<K, V> dictionary, TextWriter serializationStream) {
	   Serializer.Serialize(serializationStream, BuildItemList(dictionary));
    }
    public void Serialize(Dictionary<K, V> dictionary, Stream serializationStream) {
	   Serializer.Serialize(serializationStream, BuildItemList(dictionary));
    }

    private List<SerializableKeyValuePair<K, V>> BuildItemList(Dictionary<K, V> dictionary) {
	   List<SerializableKeyValuePair<K, V>> list = new List<SerializableKeyValuePair<K, V>>();
	   foreach (KeyValuePair<K, V> nonSerializableKVP in dictionary) {
		  list.Add(new SerializableKeyValuePair<K, V>(nonSerializableKVP));
	   }

	   return list;

    }


    public Dictionary<K, V> Deserialize(XmlReader serializationStream) {
	   List<SerializableKeyValuePair<K, V>> dictionaryItems = Serializer.Deserialize(serializationStream) as List<SerializableKeyValuePair<K, V>>;
	   return BuildDictionary(dictionaryItems);
    }
    public Dictionary<K, V> Deserialize(TextReader serializationStream) {
	   List<SerializableKeyValuePair<K, V>> dictionaryItems = Serializer.Deserialize(serializationStream) as List<SerializableKeyValuePair<K, V>>;
	   return BuildDictionary(dictionaryItems);
    }
    public Dictionary<K, V> Deserialize(Stream serializationStream) {
	   List<SerializableKeyValuePair<K, V>> dictionaryItems = Serializer.Deserialize(serializationStream) as List<SerializableKeyValuePair<K, V>>;
	   return BuildDictionary(dictionaryItems);
    }

    private Dictionary<K, V> BuildDictionary(List<SerializableKeyValuePair<K, V>> dictionaryItems) {
	   Dictionary<K, V> dictionary = new Dictionary<K, V>(dictionaryItems.Count);
	   foreach (SerializableKeyValuePair<K, V> item in dictionaryItems) {
		  dictionary.Add(item.Key, item.Value);
	   }

	   return dictionary;
    }

}