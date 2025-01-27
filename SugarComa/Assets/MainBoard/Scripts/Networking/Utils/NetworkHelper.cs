﻿using Assets.MainBoard.Scripts.Networking.LobbyNetworking;
using System.Runtime.InteropServices;

namespace Assets.MainBoard.Scripts.Networking.Utils
{
    public static class NetworkHelper
    {
        public static byte[] Serialize<T>(in T s)
            where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));

            var array = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(s, ptr, true);
            Marshal.Copy(ptr, array, 0, size);
            Marshal.FreeHGlobal(ptr);

            return array;
        }

        public static void Deserialize<T>(byte[] array, out T data)
            where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(array, 0, ptr, size);
            data = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
        }

        public static byte[] SteamIdToByteArray(Steamworks.SteamId[] idArr)
        {
            int size = Marshal.SizeOf<ulong>();
            byte[] bytes = new byte[size * SteamLobbyManager.MemberCount];

            for (int i = 0; i < SteamLobbyManager.MemberCount; i++)
            {
                byte[] tempByteArr = System.BitConverter.GetBytes((ulong)idArr[i]);
                System.Array.Copy(tempByteArr, 0, bytes, size * i, size);
            }

            return bytes;
        }

        public static Steamworks.SteamId[] ByteArrayToSteamId(byte[] bytes)
        {
            int size = Marshal.SizeOf<ulong>();
            Steamworks.SteamId[] idArr = new Steamworks.SteamId[SteamLobbyManager.MemberCount];

            for (int i = 0; i < SteamLobbyManager.MemberCount; i++)
            {
                byte[] tempArr = new byte[size];
                System.Array.Copy(bytes, size * i, tempArr, 0, size);
                idArr[i] = System.BitConverter.ToUInt64(tempArr);
            }
            return idArr;
        }
    }
}